using TravelAgencyApi.Domain.Suppliers;
using TravelAgencyApi.Domain.Users;
using TravelAgencyApi.Domain.UsersFeedback;

namespace TravelAgencyApi.Domain.TravelPackages;

// Classe PacoteViagem
public class TravelPackage{
    public Guid Travel_Package_Id {get; set;} // Id do pacote de viagem
    public required string Package_Details {get; set;} // Detalhes do pacote
    public required float Cost {get; set;} // Preço do pacote de viagem
    public required string Country {get; set;} // País de destino
    public required string Region {get; set;} // Região de destino(cidade)
    public required string Package_Name {get; set;} // Nome do pacote de viagem
    public required DateTime Travel_Date {get; set;} // Data da viagem

    public virtual ICollection<User>? Users {get; set;} // Lista de Usuários

    public virtual ICollection<UserFeedback>? UserFeedbacks {get; set;} // Lista de comentários dos usuarios

    public virtual ICollection<Supplier>? Suppliers {get; set;} // Lista de fornecedores desse pacote de viagem
}// PacoteViagem