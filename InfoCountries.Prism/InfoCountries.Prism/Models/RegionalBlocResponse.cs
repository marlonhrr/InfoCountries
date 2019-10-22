using Newtonsoft.Json;

namespace InfoCountries.Prism.Models
{
    public class RegionalBlocResponse
    {
        [JsonProperty("acronym")]
        public string Acronym { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
