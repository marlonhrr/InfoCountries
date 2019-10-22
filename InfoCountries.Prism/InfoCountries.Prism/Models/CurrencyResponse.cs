using Newtonsoft.Json;

namespace InfoCountries.Prism.Models
{
    public class CurrencyResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
