using TaxCalculator.Common.Models;
using TaxCalculator.Common.Models.Response.TaxJar;

namespace TaxCalculator.TaxClients.Interface
{
    public interface IClient
    {
        Tax CalculateOrderTaxes(object orderInfo);     
        Rate GetLocationTaxRates(string zip, object locationInfo);        
    }
}