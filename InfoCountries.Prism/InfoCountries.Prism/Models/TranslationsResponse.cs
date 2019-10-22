using Newtonsoft.Json;

namespace InfoCountries.Prism.Models
{
    public class TranslationsResponse
    {
        [JsonProperty("de")]
        public string Germany { get; set; }

        [JsonProperty("es")]
        public string Spanish { get; set; }

        [JsonProperty("fr")]
        public string French { get; set; }

        [JsonProperty("ja")]
        public string Japanese { get; set; }

        [JsonProperty("it")]
        public string Italian { get; set; }

        [JsonProperty("br")]
        public string Brazilian { get; set; }

        [JsonProperty("pt")]
        public string Portuges { get; set; }

        [JsonProperty("nl")]
        public string Dutch { get; set; }

        [JsonProperty("hr")]
        public string Croatian { get; set; }

        [JsonProperty("fa")]
        public string Danish { get; set; }
    }
}
