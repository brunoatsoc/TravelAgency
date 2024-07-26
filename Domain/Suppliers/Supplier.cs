using TravelAgencyApi.Domain.TravelPackages;

namespace TravelAgencyApi.Domain.Suppliers;

// Classe Fornecedor
public class Supplier{
    public Guid Spplier_Id {get; init;} // Id do fornecedor
    public required string Supplier_Name {get; set;} // Nome do fornecedor
    public required string Supplier_Phone {get; set;} // Telefone do fornecedor
    public required string Service_Provided {get; set;} // Serviço ddornecido pelo fornecedor

    public virtual ICollection<TravelPackage>? TravelPackages {get; set;} // Lista de Pacotes de viagem
}// Fim Fornecedor