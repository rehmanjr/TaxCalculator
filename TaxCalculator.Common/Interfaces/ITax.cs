using TaxCalculator.Common.Models.Response.TaxJar;


namespace TaxCalculator.Common.Interfaces
{
    public interface ITax
    {
        double AmountToCollect { get; set; }
        bool FreightTaxable { get; set; }
        bool HasNexus { get; set; }
        double OrderTotalAmount { get; set; }
        double Rate { get; set; }
        double Shipping { get; set; }
        long TaxableAmount { get; set; }
        string TaxSource { get; set; }
        Jurisdictions Jurisdictions { get; set; }
        Breakdown Breakdown { get; set; }
        string ExemptionType { get; set; }
    }
}