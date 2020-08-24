using Newtonsoft.Json;
using TaxCalculator.Common.Interfaces;

namespace TaxCalculator.Common.Models.Response.TaxJar
{
    public class TaxResponse
    {
        [JsonProperty("tax")]
        public Tax Tax { get; set; }
    }

    public class Tax : ITax
    {
        [JsonProperty("order_total_amount")]
        public double OrderTotalAmount { get; set; }

        [JsonProperty("shipping")]
        public double Shipping { get; set; }

        [JsonProperty("taxable_amount")]
        public long TaxableAmount { get; set; }

        [JsonProperty("amount_to_collect")]
        public double AmountToCollect { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("has_nexus")]
        public bool HasNexus { get; set; }

        [JsonProperty("freight_taxable")]
        public bool FreightTaxable { get; set; }

        [JsonProperty("tax_source")]
        public string TaxSource { get; set; }

        [JsonProperty("jurisdictions")]
        public Jurisdictions Jurisdictions { get; set; }

        [JsonProperty("breakdown")]
        public Breakdown Breakdown { get; set; }
        [JsonProperty("exemption_type")]
        public string ExemptionType { get; set; }
    }

}