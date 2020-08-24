using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculator.TaxClients.TaxJar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.TaxClients.TaxJar.Tests
{
    [TestClass()]
    public class TaxJarClientTests
    {
      
        [TestMethod()]
        public void GetLocationTaxRatesTest()
        {
            TaxJarClient TaxClient = new TaxJarClient();

            var rates = TaxClient.GetLocationTaxRates("90404");

            Assert.AreEqual("90404", rates.Zip);
            Assert.AreEqual("CA", rates.State);
            Assert.AreEqual(0.0625m, rates.StateRate);
            Assert.AreEqual("LOS ANGELES", rates.County);
            Assert.AreEqual(0.01m, rates.CountyRate);
            Assert.AreEqual("SANTA MONICA", rates.City);
            Assert.AreEqual(0.0m, rates.CityRate);
            Assert.AreEqual(0.03m, rates.CombinedDistrictRate);
            Assert.AreEqual(0.1025m, rates.CombinedRate);
            Assert.AreEqual(false, rates.FreightTaxable);
        }

        [TestMethod()]
        public void CalculateOrderTaxesTest()
        {
            TaxJarClient TaxClient = new TaxJarClient();
          
            var rates = TaxClient.CalculateOrderTaxes(new
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
                shipping = 1.5,
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

            Assert.AreEqual(16.5, rates.OrderTotalAmount);
            Assert.AreEqual(1.5, rates.Shipping);
            Assert.AreEqual(15, rates.TaxableAmount);
            Assert.AreEqual(1.43, rates.AmountToCollect);
            Assert.AreEqual(0.095, rates.Rate);
            Assert.AreEqual(true, rates.HasNexus);
            Assert.AreEqual(false, rates.FreightTaxable);
            Assert.AreEqual("destination", rates.TaxSource);


            // Jurisdictions
            Assert.AreEqual("US", rates.Jurisdictions.Country);
            Assert.AreEqual("CA", rates.Jurisdictions.State);
            Assert.AreEqual("Los Angeles County", rates.Jurisdictions.County);
            Assert.AreEqual("LOS ANGELES", rates.Jurisdictions.City);

            // Breakdowns
            Assert.AreEqual(15, rates.Breakdown.TaxableAmount);
            Assert.AreEqual(1.43, rates.Breakdown.TaxCollectable);
            Assert.AreEqual(0.095, rates.Breakdown.CombinedTaxRate);
            Assert.AreEqual(15, rates.Breakdown.StateTaxableAmount);
            Assert.AreEqual(0.0625, rates.Breakdown.StateTaxRate);
            Assert.AreEqual(0.94, rates.Breakdown.StateTaxCollectable);
            Assert.AreEqual(15, rates.Breakdown.CountyTaxableAmount);
            Assert.AreEqual(0.01, rates.Breakdown.CountyTaxRate);
            Assert.AreEqual(0.15, rates.Breakdown.CountyTaxCollectable);
            Assert.AreEqual(0, rates.Breakdown.CityTaxableAmount);
            Assert.AreEqual(0, rates.Breakdown.CityTaxRate);
            Assert.AreEqual(0, rates.Breakdown.CityTaxCollectable);
            Assert.AreEqual(15, rates.Breakdown.SpecialDistrictTaxableAmount);
            Assert.AreEqual(0.0225, rates.Breakdown.SpecialTaxRate);
            Assert.AreEqual(0.34, rates.Breakdown.SpecialDistrictTaxCollectable);

            // Line Items
            Assert.AreEqual("1", rates.Breakdown.LineItems[0].Id);
            Assert.AreEqual(15, rates.Breakdown.LineItems[0].TaxableAmount);
            Assert.AreEqual(1.43, rates.Breakdown.LineItems[0].TaxCollectable);
            Assert.AreEqual(0.095, rates.Breakdown.LineItems[0].CombinedTaxRate);
            Assert.AreEqual(15, rates.Breakdown.LineItems[0].StateTaxableAmount);
            Assert.AreEqual(0.0625, rates.Breakdown.LineItems[0].StateSalesTaxRate);
            Assert.AreEqual(0.94, rates.Breakdown.LineItems[0].StateAmount);
            Assert.AreEqual(15, rates.Breakdown.LineItems[0].CountyTaxableAmount);
            Assert.AreEqual(0.01, rates.Breakdown.LineItems[0].CountyTaxRate);
            Assert.AreEqual(0.15, rates.Breakdown.LineItems[0].CountyAmount);
            Assert.AreEqual(0, rates.Breakdown.LineItems[0].CityTaxableAmount);
            Assert.AreEqual(0, rates.Breakdown.LineItems[0].CityTaxRate);
            Assert.AreEqual(0, rates.Breakdown.LineItems[0].CityAmount);
            Assert.AreEqual(15, rates.Breakdown.LineItems[0].SpecialDistrictTaxableAmount);
            Assert.AreEqual(0.0225, rates.Breakdown.LineItems[0].SpecialTaxRate);
            Assert.AreEqual(0.34, rates.Breakdown.LineItems[0].SpecialDistrictAmount);
        }
    }
}