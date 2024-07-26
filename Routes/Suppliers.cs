using Microsoft.EntityFrameworkCore;
using TravelAgencyApi.Db;
using TravelAgencyApi.Domain.Suppliers;
using TravelAgencyApi.Domain.TravelPackages;

namespace TravelAgencyApi.Routes;

// Calasse para os endpoints dos Fornecedores
public static class Suppliers{
    // EndPoints
    public static void SuppliersEndPoints(this IEndpointRouteBuilder routes){
        var supplierRouts = routes.MapGroup("/suppliers"); // Grupo das rotas

        // APENAS ADM
        // CRUD = CREATE | HTTP = POST
        // Insere um fornecedor
        supplierRouts.MapPost("/insert_supplier/{package_id:Guid}", async (Guid package_id, SupplierRequest req, TravelAgencyApiContext context) => {
            var package = await context.TravelPackages.FirstOrDefaultAsync(tp => tp.Travel_Package_Id == package_id);

            if(package == null){
                return Results.NotFound("Travel package not found!!!");
            }

            var supplierInsert = new Supplier() {
                Supplier_Name = req.Supplier_Name,
                Supplier_Phone = req.Supplier_Phone,
                Service_Provided = req.Service_Provided,
                TravelPackages = new List<TravelPackage>()
            };

            supplierInsert.TravelPackages.Add(package);

            await context.Suppliers.AddAsync(supplierInsert);
            await context.SaveChangesAsync();
            return Results.Ok(supplierInsert);
        }).RequireAuthorization("Admin");// Fim

        // CRUD = READ | HTTP = GET
        // Mostra as informações dos Fornecedores
        supplierRouts.MapGet("/", async (TravelAgencyApiContext context) => {
            var suppliers = await context.Suppliers.Include(tp => tp.TravelPackages).ToListAsync();

            return Results.Ok(suppliers);
        });// Fim

        // APENAS ADM
        // CRUD = UPDATE | HTTP = PUT
        // Atualiza as informações de um fornecedor
        supplierRouts.MapPut("/update_supplier/{supplier_id:Guid}", async (Guid supplier_id, SupplierRequest req, TravelAgencyApiContext context) => {
            var supplierUpdate = await context.Suppliers.FirstOrDefaultAsync(s => s.Spplier_Id == supplier_id);

            if(supplierUpdate == null){
                return Results.NotFound("Supplier not found!!!");
            }

            supplierUpdate.Supplier_Name = req.Supplier_Name;
            supplierUpdate.Supplier_Phone = req.Supplier_Phone;
            supplierUpdate.Service_Provided = req.Service_Provided;

            await context.SaveChangesAsync();
            return Results.Ok(supplierUpdate);
        }).RequireAuthorization("Admin");// Fim

        // APENAS ADM
        // CRUD = UPDATE | HTTP = PUT
        // Atualiza a qual pacote a mais o fornecedor está relacionado
        supplierRouts.MapPut("/add_supplier_travelpackage/{supplier_id:Guid}/{package_id:Guid}", async (Guid supplier_id, Guid package_id, TravelAgencyApiContext context) => {
            var supplierUpdate = await context.Suppliers.FirstOrDefaultAsync(s => s.Spplier_Id == supplier_id);

            if(supplierUpdate == null){
                return Results.NotFound("Supplier not found!!!");
            }

            if(supplierUpdate.TravelPackages == null){
                supplierUpdate.TravelPackages = new List<TravelPackage>();
            }

            var package = await context.TravelPackages.FirstOrDefaultAsync(tp => tp.Travel_Package_Id == package_id);

            if(package == null){
                return Results.NotFound("Travel package not found!!!");
            }

            if(package.Suppliers == null){
                package.Suppliers = new List<Supplier>();
            }

            supplierUpdate.TravelPackages.Add(package);
            package.Suppliers.Add(supplierUpdate);

            await context.SaveChangesAsync();
            return Results.Ok(supplierUpdate);
        }).RequireAuthorization("Admin");// Fim

        // APENAS ADM
        // CRUD = DELETE | HTTP = DELETE
        // Deleta um fornecedor
        supplierRouts.MapDelete("/delete_supplier/{supplier_id:Guid}", async (Guid supplier_id, TravelAgencyApiContext context) => {
            var supplierDelete = await context.Suppliers.FirstOrDefaultAsync(s => s.Spplier_Id == supplier_id);

            if(supplierDelete == null){
                return Results.NotFound("Supplier not found!!!");
            }

            context.Suppliers.Remove(supplierDelete);
            await context.SaveChangesAsync();
            return Results.Ok(supplierDelete);
        }).RequireAuthorization("Admin");// Fim
    }// Fim EndPoints
}// Fim classe para endpoints dos Fornecedores