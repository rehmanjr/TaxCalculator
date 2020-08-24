using TaxCalculator.Service.Services;
using TaxCalculator.Common.Enum;
using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace TaxCalculator
{
    class TaxCalculator
    {
        static void Main(string[] args)
        {
            TaxService service = new TaxService(CustomerType.TypeA);

            string zipCode = "33029";

            string locationRateJson = string.Empty;
            string orderTaxRateJson = string.Empty;

            StringBuilder output = new StringBuilder();

            JObject parsed = null;

            try
            {
                var locationRate = service.GetLocationTaxRates(zipCode);

                locationRateJson = JsonConvert.SerializeObject(locationRate);

                parsed = JObject.Parse(locationRateJson);

                output.Append("***************Rates for Location***************\n\n");

                foreach (var pair in parsed)
                {
                    output.Append(string.Format("{0}: {1}", pair.Key, pair.Value) + "\n");
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var orderTaxRate = service.CalculateOrderTaxes(new
                {
                    from_country = "US",
                    from_zip = "92093",
                    from_state = "CA",
                    from_city = "La Jolla",
                    from_street = "9500 Gilman Drive",
                    to_country = "US",
                    to_zip = "90002",
                    to_state = "CA",
                    to_city = "Los Angeles",
                    to_street = "1335 E 103rd St",
                    amount = 15,
                    shipping = 1,
                    nexus_addresses = new[] {
                    new {
                      id = "Main Location",
                      country = "US",
                      zip = "92093",
                      state = "CA",
                      city = "La Jolla",
                      street = "9500 Gilman Drive",
                    }
                },
                    line_items = new[] {
                    new {
                      id = "1",
                      quantity = 1,
                      product_tax_code = "20010",
                      unit_price = 15,
                      discount = 0
                    }
                }
                });


                orderTaxRateJson = JsonConvert.SerializeObject(orderTaxRate);

                parsed = JObject.Parse(orderTaxRateJson);

                output.Append("\n\n***************Rates for Order***************\n\n");

                foreach (var pair in parsed)
                {
                    output.Append(string.Format("{0}: {1}", pair.Key, pair.Value) + "\n");                    
                    
                }
                Console.WriteLine(output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("Press any key to continue . . .");
            Console.ReadKey(true);
        }
    }


}
