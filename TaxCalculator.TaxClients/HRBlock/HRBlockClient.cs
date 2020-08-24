using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.Common.Models.Response.TaxJar;
using TaxCalculator.TaxClients.Interface;

namespace TaxCalculator.TaxClients.TaxJar
{
    public class HRBlockClient : IClient
    {
        public HRBlockClient()
        {
            

        }
        public Rate GetLocationTaxRates(string zipCode, object locationInfo = null)
        {
            return null;
        }

        public Tax CalculateOrderTaxes(object orderInfo)
        {         
            return null;
        }
    }
}
