using TravelAgencyApi.Domain.TravelPackages;
using TravelAgencyApi.Domain.UsersFeedback;

namespace TravelAgencyApi.Domain.Users;

// Classe Usuário
public class User{
    public Guid User_Id {get; init;} // Id do usuário
    public required string Full_Name {get; set;} // Nome do usuário
    public required string CPF {get; set;} // CPF do usuário
    public required string Password {get; set;} // Senha do usuário
    public required string Email {get; set;} // Email do usuário(unico)
    public required string User_Name {get; set;} // Node do usuário para o sistema(unico)
    public required string Role {get; set;} // Diz se o usuário é ADM ou usuário comum

    public virtual ICollection<TravelPackage>? TravelPackages {get; set;} // Lista de pacotes de viagem que o usuário comprou

    public virtual ICollection<UserFeedback>? UserFeedbacks {get; set;} // Lista de comentários que o usuário fez
}// Fim Usuário