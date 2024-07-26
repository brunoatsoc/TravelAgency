using System.Security.Claims;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using TravelAgencyApi.Db;
using TravelAgencyApi.Domain.Users;

namespace TravelAgencyApi.Routes;

// Classe para os endpoints dos Usuários
public static class Users{
    // EndPoints dos usuários
    public static void UsersEndpoints(this IEndpointRouteBuilder routes){
        var userRoutes = routes.MapGroup("/users"); // Grupo de rotas

        // CRUD = CREATE | HTTP = POST
        // Insere um usuário
        userRoutes.MapPost("/create_account", async (UserRequest req, IValidator<User> validator, TravelAgencyApiContext context) => {
            var alreadyExists = await context.Users.FirstOrDefaultAsync(u => u.User_Name == req.User_Name || u.Email == req.Email);

            if(alreadyExists != null){
                return Results.Conflict("User name or email already exists!!!");
            }
            var userInsert = new User() {
                Full_Name = req.Full_Name,
                CPF = req.CPF,
                Password = req.Password,
                Email = req.Email,
                User_Name = req.User_Name,
                Role = "client"
            };

            ValidationResult validationResult = await validator.ValidateAsync(userInsert);

            if(!validationResult.IsValid){
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            await context.Users.AddAsync(userInsert);
            await context.SaveChangesAsync();
            return Results.Created();
        });// Fim

        // CRUD = READ | HTTP = GET
        // Mostra as informações dos usuários
        userRoutes.MapGet("/profile/{user_id:Guid}", async (Guid user_id, TravelAgencyApiContext context) => {
            var user = await context.Users.Include(u => u.TravelPackages).FirstOrDefaultAsync(u => u.User_Id == user_id);

            if(user == null){
                return Results.NotFound("User not found!!!");
            }

            return Results.Ok( new {user.Full_Name,user.User_Name,user.Email});
        }).RequireAuthorization();// Fim

        // CRUD = UPDATE | HTTP = PUT
        // Atualiza as informações de um usuário
        userRoutes.MapPut("/update_account/{user_id:Guid}", async (Guid user_id, IValidator<User> validator, UserUpdateRequest req, TravelAgencyApiContext context) => {
            var userUpdate = await context.Users.FirstOrDefaultAsync(u => u.User_Id == user_id);

            if(userUpdate == null){
                return Results.NotFound("User not found!!!");
            }

            var alreadyExists = await context.Users.FirstOrDefaultAsync(u => u.User_Name == req.User_Name || u.Email == req.Email);

            if(alreadyExists != null && alreadyExists.User_Id != userUpdate.User_Id){
                return Results.Conflict("User name or email already exists!!!");
            }
            userUpdate.Full_Name = req.Full_Name;
            userUpdate.Email = req.Email;
            userUpdate.User_Name = req.User_Name;

            ValidationResult validationResult = await validator.ValidateAsync(userUpdate);

            if(!validationResult.IsValid){
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            await context.SaveChangesAsync();
            return Results.Ok(userUpdate);
        }).RequireAuthorization();// Fim

        // CRUD = DELETE | HTTP = DELETE
        // Deleta um usuário
        userRoutes.MapDelete("/delete_account/{user_id:Guid}", async (Guid user_id, TravelAgencyApiContext context) => {
            var userDelete = await context.Users.FirstOrDefaultAsync(u => u.User_Id == user_id);

            if(userDelete == null){
                return Results.NotFound("User not found!!!");
            }

            context.Users.Remove(userDelete);
            await context.SaveChangesAsync();
            return Results.Ok(userDelete);
        }).RequireAuthorization();// Fim
    }// Fim EndPoints
}// Fim classe dos endpoists usuários