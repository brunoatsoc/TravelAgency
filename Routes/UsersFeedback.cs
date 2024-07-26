using Microsoft.EntityFrameworkCore;
using TravelAgencyApi.Db;
using TravelAgencyApi.Domain.UsersFeedback;

namespace TravelAgencyApi.Routes;

// Classe para endpoints dos comentários dos usuários
public static class UsersFeedback{
    // EndPoints para comentários
    public static void UserFeedbackEndPoint(this IEndpointRouteBuilder routes){
        var feedbackRoutes = routes.MapGroup("/userfeedback"); // Grupo de rotas

        // CRUD = CREATE | HTTP = POST
        // Insere um novo comentário
        feedbackRoutes.MapPost("/post_comment/{user_id:Guid}/{package_id:Guid}", async (Guid user_id, Guid package_id, UserFeedbackRequest req, TravelAgencyApiContext context) => {
            var user = await context.Users.FirstOrDefaultAsync(u => u.User_Id == user_id);

            if(user == null){
                return Results.NotFound("User not found!!!");
            }

            var travelPackcage = await context.TravelPackages.FirstOrDefaultAsync(tp => tp.Travel_Package_Id == package_id);

            if(travelPackcage == null){
                return Results.NotFound("Travel package not found!!!");
            }

            var feedback = new UserFeedback() {
                Comment_Date = DateTime.Now,
                Comment = req.Comment,
                User_Id_Fk = user_id,
                User = user,
                Travel_Package_Id_Fk = package_id,
                TravelPackage = travelPackcage
            };

            if(user.UserFeedbacks == null){
                user.UserFeedbacks = new List<UserFeedback>();
            }

            if(travelPackcage.UserFeedbacks == null){
                travelPackcage.UserFeedbacks = new List<UserFeedback>();
            }

            user.UserFeedbacks.Add(feedback);
            travelPackcage.UserFeedbacks.Add(feedback);

            await context.UserFeedbacks.AddAsync(feedback);
            await context.SaveChangesAsync();
            return Results.Ok(feedback);
        });// Fim

        // CRUD = READ | HTTP = GET
        // Mostra os comnetários de um pacote de viagem
        feedbackRoutes.MapGet("/comments/{package_id:Guid}", async (Guid package_id, TravelAgencyApiContext context) => {
            var travelPackcage = await context.UserFeedbacks.Include(u => u.User).Where(f => f.Travel_Package_Id_Fk == package_id).ToListAsync();

            if(travelPackcage == null){
                return Results.NotFound("Package not found!!!");
            }

            return Results.Ok(travelPackcage);
        });// Fim

        // CRUD = DELETE | HTTP = DELETE
        // Usuário deleta o comentário que ele fez
        feedbackRoutes.MapDelete("/delete_comment/{user_id:Guid}/{feedback_id:Guid}/{package_id}", async (Guid user_id, Guid feedback_id, Guid package_id, TravelAgencyApiContext context) => {
            var feedbackRemove = await context.UserFeedbacks.FirstOrDefaultAsync(uf => uf.Feedback_Id == feedback_id && uf.User_Id_Fk == user_id && uf.Travel_Package_Id_Fk == package_id);

            if(feedbackRemove == null){
                return Results.NotFound("Comment not found!!!");
            }

            context.UserFeedbacks.Remove(feedbackRemove);
            await context.SaveChangesAsync();
            return Results.Ok(feedbackRemove);
        });// Fim

        // CRUD = UPDATE | HTTP = PUT
        // Usuário atualiza um comentário que ele fez
        feedbackRoutes.MapPut("/update_comment/{user_id:Guid}/{feedback_id:Guid}/{package_id:Guid}", async (Guid user_id, Guid feedback_id, Guid package_id, TravelAgencyApiContext context, UserFeedbackRequest req) => {
            var feedbackUpdate = await context.UserFeedbacks.FirstOrDefaultAsync(uf => uf.Feedback_Id == feedback_id && uf.User_Id_Fk == user_id && uf.Travel_Package_Id_Fk == package_id);

            if(feedbackUpdate == null){
                return Results.NotFound("Comment not found!!!");
            }

            if(feedbackUpdate.User_Id_Fk == user_id){
                feedbackUpdate.Comment = req.Comment;
                feedbackUpdate.Comment_Date = DateTime.Now;
                return Results.Ok(feedbackUpdate);
            }else{
                return Results.BadRequest("Can't update this comment!!!");
            }
        });// Fim
    }// Fim EndPoints
}// Fim endpoints dos comentários dos usuários