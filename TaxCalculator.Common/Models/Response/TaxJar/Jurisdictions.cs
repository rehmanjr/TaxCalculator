using Newtonsoft.Json;


namespace TaxCalculator.Common.Models.Response.TaxJar
{
    public class Jurisdictions
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

    }
}
