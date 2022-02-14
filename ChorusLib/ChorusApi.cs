using System;
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
        private string chorusUrl = "https://chorus.fightthe.pw";

        public ChorusApi(HttpClient httpClient)
        {
            if(httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            this.httpClient = httpClient;
        }

        public ChorusApi(HttpClient httpClient, string chorusUrl) : this(httpClient)
        {
            this.chorusUrl = chorusUrl;
        }

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

        private async Task<string> SendRequest(string requestUri)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<ChorusResults> Search(ChorusQuery query, int from = 0)
        {
            if(from < 0)
                throw new ArgumentException("Result offset must be positive.", nameof(from));
                
            string result = await SendRequest($"{chorusUrl}/api/search?query={query}&from={from}");
            ChorusResults chorusResults = JsonConvert.DeserializeObject<ChorusResults>(result);
            return chorusResults;
        }

    }
}