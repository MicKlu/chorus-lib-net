using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChorusLib.Tests
{

    [TestClass]
    public class SearchTest
    {
        [TestMethod]
        public async Task SearchByName()
        {
            string[] names = { "Hail to the King", "Down With The Sickness", "Enter Sandman" };
            ChorusQuery query = new ChorusQuery();
            foreach(var name in names)
            {
                query.Name = name;
                ChorusResults results = await ChorusApi.GetInstance().Search(query);

                Assert.IsNotNull(results, $"Expected non null result for \"{name}\"");
                Assert.IsTrue(results.Songs.Count > 0, $"Expected to find at least 1 \"{name}\"");
            }
        }

        [TestMethod]
        public async Task SearchByArtist()
        {
            string[] artists = { "Avenged Sevenfold", "Disturbed", "Metallica" };
            ChorusQuery query = new ChorusQuery();
            foreach(var artist in artists)
            {
                query.Artist = artist;
                ChorusResults results = await ChorusApi.GetInstance().Search(query);
                Assert.IsNotNull(results, $"Expected non null result for \"{artist}\"");
                Assert.IsTrue(results.Songs.Count > 0, $"Expected to find at least 1 \"{artist}\"");
            }
        }

        [TestMethod]
        public async Task EmptyQuery()
        {
            ChorusQuery query = new ChorusQuery();
            ChorusResults results = await ChorusApi.GetInstance().Search(query);
            Assert.IsNotNull(results, $"Expected non null result");
            Assert.AreEqual(20, results.Songs.Count);
        }

        [TestMethod]
        public async Task NotFound()
        {
            ChorusQuery query = new ChorusQuery() { MD5 = "abc" };
            ChorusResults results = await ChorusApi.GetInstance().Search(query);
            Assert.IsNotNull(results, $"Expected non null result");
            Assert.AreEqual(0, results.Songs.Count);
        }

        [TestMethod]
        public void NegativeOffset()
        {
            ChorusQuery query = new ChorusQuery();
            Assert.ThrowsExceptionAsync<ArgumentException>(() => {
                return ChorusApi.GetInstance().Search(query, -1);
            });
        }

        [TestMethod]
        public async Task SearchForOpenNotes()
        {
            ChorusQuery query = new ChorusQuery();
            
            query.HasOpen = true;
            ChorusResults results = await ChorusApi.GetInstance().Search(query);
            Assert.IsNotNull(results, $"Expected non null result");
            Assert.IsTrue(results.Songs.Count > 0, $"Expected to find at least 1 song");

            ChorusSongHasOpen hasOpen = results.Songs[0].HasOpen;
            Assert.IsTrue(hasOpen.GetType().GetProperties().Any(p => {
                return (bool)p.GetValue(hasOpen) == true;
            }), "Expected any property of ChorusSongHasOpen to be True");

            query.HasOpen = false;
            results = await ChorusApi.GetInstance().Search(query);
            Assert.IsNotNull(results, $"Expected non null result");
            Assert.IsTrue(results.Songs.Count > 0, $"Expected to find at least 1 song");
            hasOpen = results.Songs[0].HasOpen;

            Assert.IsTrue(hasOpen.GetType().GetProperties().All(p => {
                return (bool)p.GetValue(hasOpen) == false;
            }), "Expected all properties of ChorusSongHasOpen to be False");
        }

        [TestMethod]
        public async Task SearchForDifficultSongs()
        {
            ChorusQuery query = new ChorusQuery() { TierGuitar = new ChorusQueryTier(ChorusQueryTier.GT, 5) };
            ChorusResults results = await ChorusApi.GetInstance().Search(query);
            Assert.IsNotNull(results, $"Expected non null result");
            Assert.IsTrue(results.Songs.Count > 0, $"Expected to find at least 1 song");
            Assert.IsTrue(results.Songs[0].TierGuitar >= 5, $"Expected song with difficulty 5 or higher but got {results.Songs[0].TierGuitar}");
        }

        [TestMethod]
        public void TierArgumentsIncorrect()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                new ChorusQueryTier("", 5);
            });
        
            Assert.ThrowsException<ArgumentException>(() => {
                new ChorusQueryTier(ChorusQueryTier.GT, 7);
            });
        
            Assert.ThrowsException<ArgumentException>(() => {
                new ChorusQueryTier(ChorusQueryTier.GT, -1);
            });
        }
    }

}