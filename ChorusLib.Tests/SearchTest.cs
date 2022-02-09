using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            Assert.IsTrue(results.Songs.Count == 20, $"Expected 20 songs, found {results.Songs.Count}");
        }

        [TestMethod]
        public async Task NotFound()
        {
            ChorusQuery query = new ChorusQuery() { MD5 = "abc" };
            ChorusResults results = await ChorusApi.GetInstance().Search(query);
            Assert.IsNotNull(results, $"Expected non null result");
            Assert.IsTrue(results.Songs.Count == 0, $"Expected 0 songs, found {results.Songs.Count}");
        }

        [TestMethod]
        public void NegativeOffset()
        {
            ChorusQuery query = new ChorusQuery();
            Assert.ThrowsExceptionAsync<ArgumentException>(() => {
                return ChorusApi.GetInstance().Search(query, -1);
            });
        }
    }

}