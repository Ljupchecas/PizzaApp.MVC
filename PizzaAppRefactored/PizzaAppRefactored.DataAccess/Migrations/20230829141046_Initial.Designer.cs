﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaAppRefactored.DataAccess;

#nullable disable

namespace PizzaAppRefactored.DataAccess.Migrations
{
    [DbContext(typeof(PizzaAppDbContext))]
    [Migration("20230829141046_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzaAppRefactored.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("PizzaStore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDelivered = true,
                            PaymentMethod = 2,
                            PizzaStore = "Jakomo",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsDelivered = false,
                            PaymentMethod = 1,
                            PizzaStore = "Jakomo",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("PizzaAppRefactored.Domain.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsOnPromotion")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsOnPromotion = true,
                            Name = "Capricciosa"
                        },
                        new
                        {
                            Id = 2,
                            IsOnPromotion = false,
                            Name = "Pepperoni"
                        });
                });

            modelBuilder.Entity("PizzaAppRefactored.Domain.Models.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaSize")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaOrder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 2,
                            PizzaId = 1,
                            PizzaSize = 1,
                            Price = 300.0,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1,
                            PizzaId = 2,
                            PizzaSize = 1,
                            Price = 300.0,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("PizzaAppRefactored.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Adress1",
                            FirstName = "Ljupche",
                            LastName = "Joldashev"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Adress2",
                            FirstName = "Angela",
                            LastName = "Gjorgjievska"
                        });
                });

            modelBuilder.Entity("PizzaAppRefactored.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaAppRefactored.Domain.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PizzaAppRefactored.Domain.Models.PizzaOrder", b =>
                {
                    b.HasOne("PizzaAppRefactored.Domain.Models.Order", "Order")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaAppRefactored.Domain.Models.Pizza", "Pizza")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaAppRefactored.Domain.Models.Order", b =>
                {
                    b.Navigation("PizzaOrders");
                });

            modelBuilder.Entity("PizzaAppRefactored.Domain.Models.Pizza", b =>
                {
                    b.Navigation("PizzaOrders");
                });

            modelBuilder.Entity("PizzaAppRefactored.Domain.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
