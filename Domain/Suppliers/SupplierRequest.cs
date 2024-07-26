namespace TravelAgencyApi.Domain.Suppliers;

// Record para as requisições dos Fornecedor
public record SupplierRequest(string Supplier_Name, string Supplier_Phone, string Service_Provided);