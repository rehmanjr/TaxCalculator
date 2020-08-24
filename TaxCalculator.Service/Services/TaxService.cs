using TaxCalculator.Service.Interfaces;
using TaxCalculator.TaxClients.TaxJar;
using TaxCalculator.TaxClients.Interface;
using TaxCalculator.Common.Interfaces;
using TaxCalculator.Common.Enum;

namespace TaxCalculator.Service.Services
{
    public class TaxService : ITaxService
    {       
        IClient TaxClient { get; set; }
        public TaxService(CustomerType customerType)
        {
            switch (customerType)
            {
                case CustomerType.TypeA:
                    TaxClient = new TaxJarClient();
                    break;
                case CustomerType.TypeB:
                    break;
                default:
                    TaxClient = new TaxJarClient();
                    break;

            }

        }

        public ITaxRateResponse GetLocationTaxRates(string zipCode, object locationInfo = null)
        {         
            var response = TaxClient.GetLocationTaxRates(zipCode,locationInfo);

            return response;
        }

        public ITax CalculateOrderTaxes(object orderInfo)
        {         
            var response = TaxClient.CalculateOrderTaxes(orderInfo);

            return response;
        }

       
    }
}