using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChorusLib
{
    public class ChorusResults
    {
        [JsonProperty("songs")]
        public List<ChorusSong> Songs { get; set; }

        [JsonProperty("roles")]
        public Dictionary<string, string> Roles { get; set; }
    }
}