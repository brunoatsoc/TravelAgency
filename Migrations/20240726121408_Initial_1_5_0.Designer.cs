﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelAgencyApi.Db;

#nullable disable

namespace TravelAgency.Migrations
{
    [DbContext(typeof(TravelAgencyApiContext))]
    [Migration("20240726121408_Initial_1_5_0")]
    partial class Initial_1_5_0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("SupplierTravelPackage", b =>
                {
                    b.Property<Guid>("SuppliersSpplier_Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TravelPackagesTravel_Package_Id")
                        .HasColumnType("TEXT");

                    b.HasKey("SuppliersSpplier_Id", "TravelPackagesTravel_Package_Id");

                    b.HasIndex("TravelPackagesTravel_Package_Id");

                    b.ToTable("SupplierTravelPackage");
                });

            modelBuilder.Entity("TravelAgencyApi.Domain.Suppliers.Supplier", b =>
                {
                    b.Property<Guid>("Spplier_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Service_Provided")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Supplier_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Supplier_Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Spplier_Id");

                    b.ToTable("Suppliers", (string)null);
                });

            modelBuilder.Entity("TravelAgencyApi.Domain.TravelPackages.TravelPackage", b =>
                {
                    b.Property<Guid>("Travel_Package_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<float>("Cost")
                        .HasColumnType("REAL");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Package_Details")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Package_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Travel_Date")
                        .HasColumnType("TEXT");

                    b.HasKey("Travel_Package_Id");

                    b.ToTable("TravelPackages", (string)null);
                });

            modelBuilder.Entity("TravelAgencyApi.Domain.Users.User", b =>
                {
                    b.Property<Guid>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Full_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("User_Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("TravelAgencyApi.Domain.UsersFeedback.UserFeedback", b =>
                {
                    b.Property<Guid>("Feedback_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Comment_Date")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Travel_Package_Id_Fk")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("User_Id_Fk")
                        .HasColumnType("TEXT");

                    b.HasKey("Feedback_Id");

                    b.HasIndex("Travel_Package_Id_Fk");

                    b.HasIndex("User_Id_Fk");

                    b.ToTable("UserFeedbacks", (string)null);
                });

            modelBuilder.Entity("TravelPackageUser", b =>
                {
                    b.Property<Guid>("TravelPackagesTravel_Package_Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UsersUser_Id")
                        .HasColumnType("TEXT");

                    b.HasKey("TravelPackagesTravel_Package_Id", "UsersUser_Id");

                    b.HasIndex("UsersUser_Id");

                    b.ToTable("TravelPackageUser");
                });

            modelBuilder.Entity("SupplierTravelPackage", b =>
                {
                    b.HasOne("TravelAgencyApi.Domain.Suppliers.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SuppliersSpplier_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgencyApi.Domain.TravelPackages.TravelPackage", null)
                        .WithMany()
                        .HasForeignKey("TravelPackagesTravel_Package_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelAgencyApi.Domain.UsersFeedback.UserFeedback", b =>
                {
                    b.HasOne("TravelAgencyApi.Domain.TravelPackages.TravelPackage", "TravelPackage")
                        .WithMany("UserFeedbacks")
                        .HasForeignKey("Travel_Package_Id_Fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgencyApi.Domain.Users.User", "User")
                        .WithMany("UserFeedbacks")
                        .HasForeignKey("User_Id_Fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TravelPackage");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TravelPackageUser", b =>
                {
                    b.HasOne("TravelAgencyApi.Domain.TravelPackages.TravelPackage", null)
                        .WithMany()
                        .HasForeignKey("TravelPackagesTravel_Package_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TravelAgencyApi.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUser_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TravelAgencyApi.Domain.TravelPackages.TravelPackage", b =>
                {
                    b.Navigation("UserFeedbacks");
                });

            modelBuilder.Entity("TravelAgencyApi.Domain.Users.User", b =>
                {
                    b.Navigation("UserFeedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}