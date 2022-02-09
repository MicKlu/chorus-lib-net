using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChorusLib
{
    public class ChorusApi
    {
        private static ChorusApi instance;
        private static readonly object instanceLock = new object();
        private HttpClient httpClient;
        private const string ENDPOINT = "https://chorus.fightthe.pw/api/search";

        private ChorusApi()
        {
            if(httpClient == null)
                httpClient = new HttpClient();
        }

        public static ChorusApi GetInstance()
        {
            if(instance == null)
                lock(instanceLock)
                    if (instance == null)
                        instance = new ChorusApi();
            return instance;
        }

        public async Task<ChorusResults> Search(ChorusQuery query, int from = 0)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{ENDPOINT}?query={query}&from={from}");
            HttpResponseMessage response = await httpClient.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            ChorusResults chorusResults = JsonConvert.DeserializeObject<ChorusResults>(result);
            return chorusResults;
        }

    }
}