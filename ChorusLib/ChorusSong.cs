using System.Collections.Generic;
using Newtonsoft.Json;

namespace ChorusLib
{
    public class ChorusSong
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("album")]
        public string Album { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("year")]
        public short? Year { get; set; }

        [JsonProperty("charter")]
        public string Charter { get; set; }

        [JsonProperty("length")]
        public int? Length { get; set; }

        [JsonProperty("effectiveLength")]
        public int? EffectiveLength { get; set; }

        [JsonProperty("tier_band")]
        public int? TierBand { get; set; }

        [JsonProperty("tier_guitar")]
        public int? TierGuitar { get; set; }

        [JsonProperty("tier_bass")]
        public int? TierBass { get; set; }

        [JsonProperty("tier_rhythm")]
        public int? TierRhythm { get; set; }

        [JsonProperty("tier_drums")]
        public int? TierDrums { get; set; }

        [JsonProperty("tier_vocals")]
        public int? TierVocals { get; set; }

        [JsonProperty("tier_keys")]
        public int? TierKeys { get; set; }

        [JsonProperty("tier_guitarghl")]
        public int? TierGuitarGHL { get; set; }

        [JsonProperty("tier_bassghl")]
        public int? TierBassGHL { get; set; }

        [JsonProperty("diff_guitar")]
        public int? DiffGuitar { get; set; }

        [JsonProperty("diff_bass")]
        public int? DiffBass { get; set; }

        [JsonProperty("diff_rhythm")]
        public int? DiffRhythm { get; set; }

        [JsonProperty("diff_drums")]
        public int? DiffDrums { get; set; }

        [JsonProperty("diff_keys")]
        public int? DiffKeys { get; set; }

        [JsonProperty("diff_guitarghl")]
        public int? DiffGuitarGHL { get; set; }

        [JsonProperty("diff_bassghl")]
        public int? DiffBassGHL { get; set; }

        [JsonProperty("isPack")]
        public bool? IsPack { get; set; }

        [JsonProperty("hasForced")]
        public bool? HasForced { get; set; }

        [JsonProperty("hasOpen")]
        public ChorusSongHasOpen HasOpen { get; set; }

        [JsonProperty("hasTap")]
        public bool? HasTap { get; set; }

        [JsonProperty("hasSections")]
        public bool? HasSections { get; set; }

        [JsonProperty("hasStarPower")]
        public bool? HasStarPower { get; set; }

        [JsonProperty("hasSoloSections")]
        public bool? HasSoloSections { get; set; }

        [JsonProperty("is120")]
        public bool? Is120 { get; set; }

        [JsonProperty("hasStems")]
        public bool? HasStems { get; set; }

        [JsonProperty("hasVideo")]
        public bool? HasVideo { get; set; }

        [JsonProperty("hasLyrics")]
        public bool? HasLyrics { get; set; }

        [JsonProperty("hasNoAudio")]
        public bool? HasNoAudio { get; set; }

        [JsonProperty("needsRenaming")]
        public bool? NeedsRenaming { get; set; }

        [JsonProperty("isFolder")]
        public bool? IsFolder { get; set; }

        [JsonProperty("hasBrokenNotes")]
        public bool? HasBrokenNotes { get; set; }

        [JsonProperty("hasBackground")]
        public bool? HasBackground { get; set; }

        [JsonProperty("noteCounts")]
        public ChorusSongNoteCounts NoteCounts { get; set; }

        [JsonProperty("lastModified")]
        public string LastModified { get; set; }

        [JsonProperty("uploadedAt")]
        public string UploadedAt { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("directLinks")]
        public ChorusSongDirectLinks DirectLinks { get; set; }

        [JsonProperty("songId")]
        public int? SongId { get; set; }

        [JsonProperty("sources")]
        public List<ChorusSource> Sources { get; set; }

        [JsonProperty("hashes")]
        public ChorusSongHashes Hashes { get; set; }
    }
}