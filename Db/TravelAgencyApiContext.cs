using Microsoft.EntityFrameworkCore;
using TravelAgencyApi.Domain.Suppliers;
using TravelAgencyApi.Domain.TravelPackages;
using TravelAgencyApi.Domain.Users;
using TravelAgencyApi.Domain.UsersFeedback;

namespace TravelAgencyApi.Db;

public class TravelAgencyApiContext : DbContext{
    public DbSet<User> Users {get; set;} // Tabela Usuários
    public DbSet<UserFeedback> UserFeedbacks {get; set;} // Tabela de Comentários
    public DbSet<TravelPackage> TravelPackages {get; set;} // Tabela de Pacotes de Viagem
    public DbSet<Supplier> Suppliers {get; set;} // Tabela de Fornecedores

    // Configuração das tabelas e seus relacionamentos
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        // Configuração da tabela Users
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(u => u.User_Id);
        modelBuilder.Entity<User>().HasMany(u => u.UserFeedbacks).WithOne(u => u.User).HasForeignKey(fk => fk.User_Id_Fk).OnDelete(DeleteBehavior.Cascade);

        // Configuração da tabela UserFeedbacks
        modelBuilder.Entity<UserFeedback>().ToTable("UserFeedbacks");
        modelBuilder.Entity<UserFeedback>().HasKey(uf => uf.Feedback_Id);
        modelBuilder.Entity<UserFeedback>().HasOne(uf => uf.TravelPackage).WithMany(uf => uf.UserFeedbacks).HasForeignKey(fk => fk.Travel_Package_Id_Fk).OnDelete(DeleteBehavior.Cascade);

        // Configuração da tabela TravelPackages
        modelBuilder.Entity<TravelPackage>().ToTable("TravelPackages");
        modelBuilder.Entity<TravelPackage>().HasKey(tp => tp.Travel_Package_Id);
        modelBuilder.Entity<TravelPackage>().HasMany(tp => tp.Users).WithMany(tp => tp.TravelPackages);

        // Configuração da tabela Suppliers
        modelBuilder.Entity<Supplier>().ToTable("Suppliers");
        modelBuilder.Entity<Supplier>().HasKey(s => s.Spplier_Id);
        modelBuilder.Entity<Supplier>().HasMany(s => s.TravelPackages).WithMany(s => s.Suppliers);
    }// Fim OnModelCreating

    // Configuração do banco de dados
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        var stringconnection = "Data Source=TravelAgency.db";

        optionsBuilder.UseSqlite(stringconnection).EnableSensitiveDataLogging().EnableDetailedErrors();
    }// Fim OnConfiguring
}// Fim TravelAgencyApiContext