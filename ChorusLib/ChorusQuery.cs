using System;
using System.Collections.Generic;
using System.Reflection;

namespace ChorusLib
{
    public class ChorusQuery
    {
        [ChorusQueryKey("name", Quoted = true)]
        public string Name { get; set; }

        [ChorusQueryKey("artist", Quoted = true)]
        public string Artist { get; set; }

        [ChorusQueryKey("album", Quoted = true)]
        public string Album { get; set; }

        [ChorusQueryKey("genre", Quoted = true)]
        public string Genre { get; set; }

        [ChorusQueryKey("charter", Quoted = true)]
        public string Charter { get; set; }

        [ChorusQueryKey("md5")]
        public string MD5 { get; set; }
        
        [ChorusQueryKey("tier_band")]
        public ChorusQueryTier TierBand { get; set; }
        
        [ChorusQueryKey("tier_guitar")]
        public ChorusQueryTier TierGuitar { get; set; }
        
        [ChorusQueryKey("tier_bass")]
        public ChorusQueryTier TierBass { get; set; }
        
        [ChorusQueryKey("tier_rhythm")]
        public ChorusQueryTier TierRhythm { get; set; }
        
        [ChorusQueryKey("tier_drums")]
        public ChorusQueryTier TierDrums { get; set; }
        
        [ChorusQueryKey("tier_vocals")]
        public ChorusQueryTier TierVocals { get; set; }
        
        [ChorusQueryKey("tier_keys")]
        public ChorusQueryTier TierKeys { get; set; }
        
        [ChorusQueryKey("tier_guitarghl")]
        public ChorusQueryTier TierGuitarGHL { get; set; }
        
        [ChorusQueryKey("tier_bassghl")]
        public ChorusQueryTier TierBassGHL { get; set; }

        [ChorusQueryKey("hasForced")]
        public bool? HasForced { get; set; }
        
        [ChorusQueryKey("hasOpen")]
        public bool? HasOpen { get; set; }
        
        [ChorusQueryKey("hasTap")]
        public bool? HasTap { get; set; }
        
        [ChorusQueryKey("hasSections")]
        public bool? HasSections { get; set; }
        
        [ChorusQueryKey("hasStarPower")]
        public bool? HasStarPower { get; set; }
        
        [ChorusQueryKey("hasSoloSections")]
        public bool? HasSoloSections { get; set; }
        
        [ChorusQueryKey("hasStems")]
        public bool? HasStems { get; set; }
        
        [ChorusQueryKey("hasVideo")]
        public bool? HasVideo { get; set; }
        
        [ChorusQueryKey("hasLyrics")]
        public bool? HasLyrics { get; set; }

        public ChorusQuery() { }

        public override string ToString()
        {
            List<string> query = new List<string>();
            foreach(PropertyInfo prop in this.GetType().GetProperties())
            {
                ChorusQueryKeyAttribute attr = prop.GetCustomAttribute<ChorusQueryKeyAttribute>();
                if(attr == null)
                    continue;
                
                object value = prop.GetValue(this);
                if(value == null)
                    continue;

                string queryValue = String.Empty;
                if(value is string || value is ChorusQueryTier)
                    queryValue = value.ToString();
                else if(value is bool)
                    queryValue = (bool)value ? "1" : "0";

                if(attr.Quoted)
                    queryValue = $"\"{queryValue}\"";

                query.Add(Uri.EscapeDataString($"{attr.Key}={queryValue}"));
            }
            return String.Join(" ", query);
        }
    }
}