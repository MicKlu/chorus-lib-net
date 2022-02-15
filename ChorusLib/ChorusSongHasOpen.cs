using Newtonsoft.Json;

namespace ChorusLib
{
    public class ChorusSongHasOpen
    {
        [JsonProperty("guitar")]
        public bool Guitar { get; set; }

        [JsonProperty("rhythm")]
        public bool Rhythm { get; set; }

        [JsonProperty("bass")]
        public bool Bass { get; set; }

        [JsonProperty("guitarghl")]
        public bool GuitarGHL { get; set; }

        [JsonProperty("bassghl")]
        public bool BassGHL { get; set; }
    }
}