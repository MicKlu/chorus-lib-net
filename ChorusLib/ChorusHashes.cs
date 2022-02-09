using Newtonsoft.Json;

namespace ChorusLib
{
    public class ChorusHashes
    {
        [JsonProperty("e")]
        public string Easy { get; set; }

        [JsonProperty("m")]
        public string Medium { get; set; }

        [JsonProperty("h")]
        public string Hard { get; set; }

        [JsonProperty("x")]
        public string Expert { get; set; }
    }
}