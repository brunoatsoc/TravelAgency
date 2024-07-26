namespace TravelAgencyApi.Domain.TravelPackages;

// Record para as requisições dos pacotes de viagem
public record TravelPackageRequest(string Package_Details, float Cost, string Country, string Region, string Package_Name, DateTime Travel_Date);