using Newtonsoft.Json;

namespace ChorusLib
{
    public class ChorusSourceParent
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }
}