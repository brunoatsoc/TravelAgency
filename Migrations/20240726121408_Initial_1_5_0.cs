using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Migrations
{
    /// <inheritdoc />
    public partial class Initial_1_5_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Spplier_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Supplier_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Supplier_Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Service_Provided = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Spplier_Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelPackages",
                columns: table => new
                {
                    Travel_Package_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Package_Details = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<float>(type: "REAL", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    Package_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Travel_Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPackages", x => x.Travel_Package_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Full_Name = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    User_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierTravelPackage",
                columns: table => new
                {
                    SuppliersSpplier_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TravelPackagesTravel_Package_Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTravelPackage", x => new { x.SuppliersSpplier_Id, x.TravelPackagesTravel_Package_Id });
                    table.ForeignKey(
                        name: "FK_SupplierTravelPackage_Suppliers_SuppliersSpplier_Id",
                        column: x => x.SuppliersSpplier_Id,
                        principalTable: "Suppliers",
                        principalColumn: "Spplier_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierTravelPackage_TravelPackages_TravelPackagesTravel_Package_Id",
                        column: x => x.TravelPackagesTravel_Package_Id,
                        principalTable: "TravelPackages",
                        principalColumn: "Travel_Package_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelPackageUser",
                columns: table => new
                {
                    TravelPackagesTravel_Package_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsersUser_Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPackageUser", x => new { x.TravelPackagesTravel_Package_Id, x.UsersUser_Id });
                    table.ForeignKey(
                        name: "FK_TravelPackageUser_TravelPackages_TravelPackagesTravel_Package_Id",
                        column: x => x.TravelPackagesTravel_Package_Id,
                        principalTable: "TravelPackages",
                        principalColumn: "Travel_Package_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelPackageUser_Users_UsersUser_Id",
                        column: x => x.UsersUser_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFeedbacks",
                columns: table => new
                {
                    Feedback_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Comment_Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    User_Id_Fk = table.Column<Guid>(type: "TEXT", nullable: false),
                    Travel_Package_Id_Fk = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeedbacks", x => x.Feedback_Id);
                    table.ForeignKey(
                        name: "FK_UserFeedbacks_TravelPackages_Travel_Package_Id_Fk",
                        column: x => x.Travel_Package_Id_Fk,
                        principalTable: "TravelPackages",
                        principalColumn: "Travel_Package_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFeedbacks_Users_User_Id_Fk",
                        column: x => x.User_Id_Fk,
                        principalTable: "Users",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTravelPackage_TravelPackagesTravel_Package_Id",
                table: "SupplierTravelPackage",
                column: "TravelPackagesTravel_Package_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPackageUser_UsersUser_Id",
                table: "TravelPackageUser",
                column: "UsersUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeedbacks_Travel_Package_Id_Fk",
                table: "UserFeedbacks",
                column: "Travel_Package_Id_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeedbacks_User_Id_Fk",
                table: "UserFeedbacks",
                column: "User_Id_Fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierTravelPackage");

            migrationBuilder.DropTable(
                name: "TravelPackageUser");

            migrationBuilder.DropTable(
                name: "UserFeedbacks");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "TravelPackages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
