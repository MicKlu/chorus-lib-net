using System;
using System.Collections.Generic;

namespace ChorusLib
{
    public class ChorusQuery
    {
        private readonly string[] KEYS = new string[]
            { "name", "artist", "album", "genre", "charter", "md5" };

        private Dictionary<string, string> queryData = new Dictionary<string, string>();
        
        public string Name
        {
            get => queryData["name"];
            set { queryData["name"] = $"\"{value}\""; }
        }

        public string Artist
        {
            get => queryData["artist"];
            set { queryData["artist"] = $"\"{value}\""; }
        }

        public string Album
        {
            get => queryData["album"];
            set { queryData["album"] = $"\"{value}\""; }
        }

        public string Genre
        {
            get => queryData["genre"];
            set { queryData["genre"] = $"\"{value}\""; }
        }

        public string Charter
        {
            get => queryData["charter"];
            set { queryData["charter"] = $"\"{value}\""; }
        }

        public string MD5
        {
            get => queryData["md5"];
            set { queryData["md5"] = value; }
        }

        public ChorusQuery()
        {
            foreach(string key in KEYS)
                queryData.Add(key, String.Empty);
        }

        public override string ToString()
        {
            List<string> query = new List<string>();

            foreach(KeyValuePair<string, string> pair in queryData)
            {
                if(pair.Value.Length > 0)
                    query.Add(Uri.EscapeDataString($"{pair.Key}={pair.Value}"));
            }
            
            return String.Join(" ", query);
        }
    }
}