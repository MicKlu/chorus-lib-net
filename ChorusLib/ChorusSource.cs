using Newtonsoft.Json;

namespace ChorusLib
{
    public class ChorusSource
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("parent")]
        public ChorusSourceParent Parent { get; set; }

        [JsonProperty("isSetlist")]
        public bool? IsSetlist { get; set; }
    }
}