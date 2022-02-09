using Newtonsoft.Json;

namespace ChorusLib
{
    public class ChorusNoteCounts
    {
        [JsonProperty("e")]
        public int? Easy { get; set; }

        [JsonProperty("m")]
        public int? Medium { get; set; }

        [JsonProperty("h")]
        public int? Hard { get; set; }

        [JsonProperty("x")]
        public int? Expert { get; set; }

    }
}