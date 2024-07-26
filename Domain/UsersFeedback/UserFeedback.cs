using TravelAgencyApi.Domain.TravelPackages;
using TravelAgencyApi.Domain.Users;

namespace TravelAgencyApi.Domain.UsersFeedback;

// Classe de comentários dos usuários
public class UserFeedback{
    public Guid Feedback_Id {get; init;} // Id do comentário
    public DateTime Comment_Date {get; set;} // Data do comentário
    public string? Comment {get; set;} // Comentário do usuário

    public Guid User_Id_Fk {get; set;} // Id do usuário(chave estrangeira)
    public virtual User? User {get; set;} // Usuário que fez o comentário

    public Guid Travel_Package_Id_Fk {get; set;} // Id do pacote de viagem(chave estrangeira)
    public virtual TravelPackage? TravelPackage {get; set;} // Pacote de viagem em que o comentário está
}// Fim classe de comentários dos usuários