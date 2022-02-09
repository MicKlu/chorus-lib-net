using Newtonsoft.Json;

namespace ChorusLib
{
    public class ChorusSongHashes
    {
        [JsonProperty("file")]
        public string File { get; set; }

        [JsonProperty("guitar")]
        public ChorusHashes Guitar { get; set; }

        [JsonProperty("rhythm")]
        public ChorusHashes Rhythm { get; set; }

        [JsonProperty("bass")]
        public ChorusHashes Bass { get; set; }

        [JsonProperty("drums")]
        public ChorusHashes Drums { get; set; }

        [JsonProperty("vocals")]
        public ChorusHashes Vocals { get; set; }

        [JsonProperty("keys")]
        public ChorusHashes Keys { get; set; }

        [JsonProperty("guitarghl")]
        public ChorusHashes GuitarGHL { get; set; }

        [JsonProperty("bassghl")]
        public ChorusHashes BassGHL { get; set; }
    }
}