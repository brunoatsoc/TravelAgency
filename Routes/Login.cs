using Microsoft.EntityFrameworkCore;
using TravelAgencyApi.Db;
using LoginRequest = TravelAgencyApi.Domain.Login.LoginRequest;

namespace TravelAgencyApi.Routes;

// Classe para o Login de um usuário
public static class Login{
    // Endpoints
    public static void LoginEndPoints(this IEndpointRouteBuilder routes){
        var loginRoute = routes.MapGroup("/login"); // Grupo para a rota login

        // CRUD = CREATE | HTTP = POST
        loginRoute.MapPost("", async (LoginRequest req, TravelAgencyApiContext context, IConfiguration configuration) => {
            var user = await context.Users.FirstOrDefaultAsync(u => u.User_Name == req.User_Name && u.Password == req.Password);

            if(user == null){
                return Results.Unauthorized();
            }

            var token = TokenService.TokenService.GenerateToken(user);

            user.Password = "";

            return Results.Ok(new {
                user = new {user.User_Id, user.Full_Name, user.Role},
                token = token
            });
        });// Fim

    }// Fim Endpoints
}// Fim classe Login