namespace TravelAgencyApi.Domain.Users;

// Record para as requisições de Usuários
public record UserRequest(string Full_Name, string CPF, string Password, string Email, string User_Name);
public record UserUpdateRequest(string Full_Name, string Email, string User_Name);