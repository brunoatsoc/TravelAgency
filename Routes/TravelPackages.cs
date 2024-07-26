using Microsoft.EntityFrameworkCore;
using TravelAgencyApi.Db;
using TravelAgencyApi.Domain.TravelPackages;
using TravelAgencyApi.Domain.Users;

namespace TravelAgencyApi.Routes;

// Classe para os endpoints dos pacotes de viagem
public static class TravelPackages{
    // EndPoints pacotes de viagem
    public static void TravelPackagesEndPoints(this IEndpointRouteBuilder routes){
        var travelRouts = routes.MapGroup("/travelpackages"); // Grupo de rotas

        // APENAS ADM
        // CRUD = CREATE | HTTP = POST
        // Insere um pacote de viagem
        travelRouts.MapPost("/insert_travelpackage", async (TravelPackageRequest req, TravelAgencyApiContext context) => {
            var travelPackage = new TravelPackage() {
                Package_Details = req.Package_Details,
                Cost = req.Cost,
                Country = req.Country,
                Region = req.Region,
                Package_Name = req.Package_Name,
                Travel_Date = req.Travel_Date
            };

            await context.TravelPackages.AddAsync(travelPackage);
            await context.SaveChangesAsync();
            return Results.Ok(travelPackage);
        }).RequireAuthorization("Admin");// Fim

        // CRUD = READ | HTTP = GET
        // Mostra as informações dos pacotes de viagem
        travelRouts.MapGet("/", async (TravelAgencyApiContext context) => {
            var packages = await context.TravelPackages.Include(s => s.Suppliers).Include(uf => uf.UserFeedbacks).ThenInclude(u => u.User).ToListAsync();

            return Results.Ok(packages);
        });// Fim

        // APENAS ADM
        // CRUD = UPDATE | HTTP = PUT
        // Atualiza as informações de um pacote de viagem
        travelRouts.MapPut("/update_travelpackage/{package_id:Guid}", async (Guid package_id, TravelPackageRequest req, TravelAgencyApiContext context) => {
            var package = await context.TravelPackages.FirstOrDefaultAsync(tp => tp.Travel_Package_Id == package_id);

            if(package == null){
                return Results.NotFound("Travel package not found!!!");
            }

            package.Package_Details = req.Package_Details;
            package.Country = req.Country;
            package.Region = req.Region;
            package.Package_Name = req.Package_Name;
            package.Travel_Date = req.Travel_Date;

            await context.SaveChangesAsync();
            return Results.Ok(package);
        }).RequireAuthorization("Admin");// Fim

        // APENAS ADM
        // CRUD = UPDATE | HTTP = PUT
        // Faz a compra de um pacote de viagem
        travelRouts.MapPut("/buy_package/{user_id:Guid}/{package_id:Guid}", async (Guid user_id, Guid package_id, TravelAgencyApiContext context) => {
            var user = await context.Users.FirstOrDefaultAsync(u => u.User_Id == user_id);

            if(user == null){
                return Results.NotFound("User not found!!!");
            }

            var package = await context.TravelPackages.FirstOrDefaultAsync(tp => tp.Travel_Package_Id == package_id);

            if(package == null){
                return Results.NotFound("Travel package not found!!!");
            }

            if(package.Users == null){
                package.Users = new List<User>();
            }

            if(user.TravelPackages == null){
                user.TravelPackages = new List<TravelPackage>();
            }

            package.Users.Add(user);
            user.TravelPackages.Add(package);

            await context.SaveChangesAsync();
            return Results.Ok(package);
        }).RequireAuthorization();// Fim

        // APENAS ADM
        // CRUD = DELETE | HTTP = DELETE
        // Deleta um pacote de viagem
        travelRouts.MapDelete("/delete_travelpackage/{package_id:Guid}", async (Guid package_id, TravelAgencyApiContext context) => {
            var package = await context.TravelPackages.FirstOrDefaultAsync(tp => tp.Travel_Package_Id == package_id);

            if(package == null){
                return Results.NotFound("Travelpackage not found!!!");
            }

            context.TravelPackages.Remove(package);
            await context.SaveChangesAsync();
            return Results.Ok(package);
        }).RequireAuthorization("Admin");// Fim
    }// Fim EndPoints
}// Fim classe endpoints pacotes de viagem