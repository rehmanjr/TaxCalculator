using TaxCalculator.Common.Interfaces;

namespace TaxCalculator.Service.Interfaces
{
    public interface ITaxService
    {
        ITax CalculateOrderTaxes(object orderInfo);
        ITaxRateResponse GetLocationTaxRates(string zipCode,object locationInfo);
    }
}