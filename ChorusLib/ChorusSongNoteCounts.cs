using Newtonsoft.Json;

namespace ChorusLib
{
    public class ChorusSongNoteCounts
    {
        [JsonProperty("guitar")]
        public ChorusNoteCounts Guitar { get; set; }

        [JsonProperty("rhythm")]
        public ChorusNoteCounts Rhythm { get; set; }

        [JsonProperty("bass")]
        public ChorusNoteCounts Bass { get; set; }

        [JsonProperty("drums")]
        public ChorusNoteCounts Drums { get; set; }

        [JsonProperty("vocals")]
        public ChorusNoteCounts Vocals { get; set; }

        [JsonProperty("keys")]
        public ChorusNoteCounts Keys { get; set; }

        [JsonProperty("guitarghl")]
        public ChorusNoteCounts GuitarGHL { get; set; }

        [JsonProperty("bassghl")]
        public ChorusNoteCounts BassGHL { get; set; }
    }
}