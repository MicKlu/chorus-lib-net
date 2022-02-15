using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChorusLib.Tests
{

    [TestClass]
    public class CreateTest
    {
        [TestMethod]
        public async Task CreateSingleton()
        {
            ChorusApi api = ChorusApi.GetInstance();
            ChorusResults results = await api.Search(new ChorusQuery());
            Assert.IsNotNull(results, $"Expected non null result");
            Assert.AreEqual(20, results.Songs.Count);
        }

        [TestMethod]
        public async Task CreateHttpClient()
        {
            HttpClient httpClient = new HttpClient();
            ChorusApi api = new ChorusApi(httpClient);
            ChorusResults results = await api.Search(new ChorusQuery());
            Assert.IsNotNull(results, $"Expected non null result");
            Assert.AreEqual(20, results.Songs.Count);
        }

        [TestMethod]
        public void CreateHttpClientNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => {
                ChorusApi api = new ChorusApi(null);
            });
        }

        [TestMethod]
        public async Task CreateHttpClientAndChorusUrl()
        {
            HttpClient httpClient = new HttpClient();
            ChorusApi api = new ChorusApi(httpClient, "https://chorus.fightthe.pw");
            ChorusResults results = await api.Search(new ChorusQuery());
            Assert.IsNotNull(results, $"Expected non null result");
            Assert.AreEqual(20, results.Songs.Count);
        }

        [TestMethod]
        public void CreateHttpClientAndChorusUrlMisspelled()
        {
            HttpClient httpClient = new HttpClient();
            ChorusApi api = new ChorusApi(httpClient, "https://choruss.fightthe.pw");
            Assert.ThrowsExceptionAsync<HttpRequestException>(async () => {
                ChorusResults results = await api.Search(new ChorusQuery());
            });
        }
    }

}