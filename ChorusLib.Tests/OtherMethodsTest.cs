using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace ChorusLib.Tests
{

    [TestClass]
    public class OtherMethodsTest
    {
        [TestMethod]
        public async Task Count()
        {
            ChorusApi api = ChorusApi.GetInstance();
            int count = await api.Count();
            Assert.IsTrue(count >= 0, $"Expected value 0 or more, but got \"{count}\"");
        }

        [TestMethod]
        public async Task Random()
        {
            ChorusApi api = ChorusApi.GetInstance();
            ChorusResults chorusResults = await api.Random();
            
            Assert.IsNotNull(chorusResults);
            Assert.AreEqual(20, chorusResults.Songs.Count);

            ChorusResults newChorusResults = await api.Random();

            Assert.IsNotNull(newChorusResults);
            Assert.AreEqual(20, newChorusResults.Songs.Count);
            Assert.AreNotEqual(chorusResults.Songs[0].Id, newChorusResults.Songs[0].Id);
        }
    }

}