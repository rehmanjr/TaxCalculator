using Newtonsoft.Json;


namespace TaxCalculator.Common.Models.Response.TaxJar
{
    public class LineItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("taxable_amount")]
        public long TaxableAmount { get; set; }

        [JsonProperty("tax_collectable")]
        public double TaxCollectable { get; set; }

        [JsonProperty("combined_tax_rate")]
        public double CombinedTaxRate { get; set; }

        [JsonProperty("state_taxable_amount")]
        public long StateTaxableAmount { get; set; }

        [JsonProperty("state_sales_tax_rate")]
        public double StateSalesTaxRate { get; set; }

        [JsonProperty("state_amount")]
        public double StateAmount { get; set; }

        [JsonProperty("county_taxable_amount")]
        public long CountyTaxableAmount { get; set; }

        [JsonProperty("county_tax_rate")]
        public double CountyTaxRate { get; set; }

        [JsonProperty("county_amount")]
        public double CountyAmount { get; set; }

        [JsonProperty("city_taxable_amount")]
        public long CityTaxableAmount { get; set; }

        [JsonProperty("city_tax_rate")]
        public long CityTaxRate { get; set; }

        [JsonProperty("city_amount")]
        public long CityAmount { get; set; }

        [JsonProperty("special_district_taxable_amount")]
        public long SpecialDistrictTaxableAmount { get; set; }

        [JsonProperty("special_tax_rate")]
        public double SpecialTaxRate { get; set; }

        [JsonProperty("special_district_amount")]
        public double SpecialDistrictAmount { get; set; }
    }
}
