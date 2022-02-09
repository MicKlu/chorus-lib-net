using Newtonsoft.Json;

namespace ChorusLib
{
    public class ChorusSongDirectLinks
    {
        [JsonProperty("archive")]
        public string Archive { get; set; }
        
        [JsonProperty("album")]
        public string Album { get; set; }
        
        [JsonProperty("album.png")]
        public string AlbumPNG { get; set; }
        
        [JsonProperty("chart")]
        public string Chart { get; set; }
        
        [JsonProperty("ini")]
        public string Ini { get; set; }
        
        [JsonProperty("song.ogg")]
        public string SongOGG { get; set; }
        
        [JsonProperty("video")]
        public string Video { get; set; }
        
    }
}