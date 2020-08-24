namespace TaxCalculator.Common.Interfaces
{
    public interface ITaxRateResponse
    {
        string City { get; set; }
        decimal CityRate { get; set; }
        decimal CombinedDistrictRate { get; set; }
        decimal CombinedRate { get; set; }
        string Country { get; set; }
        decimal CountryRate { get; set; }
        string County { get; set; }
        decimal CountyRate { get; set; }
        decimal DistanceSaleThreshold { get; set; }
        bool FreightTaxable { get; set; }
        string Name { get; set; }
        decimal ParkingRate { get; set; }
        decimal ReducedRate { get; set; }
        decimal StandardRate { get; set; }
        string State { get; set; }
        decimal StateRate { get; set; }
        decimal SuperReducedRate { get; set; }
        string Zip { get; set; }
    }
}