﻿// <auto-generated />
using System;
using Carsalesbyhoho.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Carsalesbyhoho.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("Carsalesbyhoho.Models.Auto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AfbeeldingUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("AutoTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bouwjaar")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Omschrijving")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Prijs")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AutoTypeId");

                    b.HasIndex("BrandId");

                    b.ToTable("Autos");
                });

            modelBuilder.Entity("Carsalesbyhoho.Models.AutoType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Omschrijving")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AutoTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Omschrijving = "SUV"
                        },
                        new
                        {
                            Id = 2,
                            Omschrijving = "Break"
                        },
                        new
                        {
                            Id = 3,
                            Omschrijving = "Sedan"
                        },
                        new
                        {
                            Id = 4,
                            Omschrijving = "Hatchback"
                        },
                        new
                        {
                            Id = 5,
                            Omschrijving = "Cabriolet"
                        });
                });

            modelBuilder.Entity("Carsalesbyhoho.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Naam = "Diesel"
                        },
                        new
                        {
                            Id = 2,
                            Naam = "Benzine"
                        },
                        new
                        {
                            Id = 3,
                            Naam = "Elektrisch"
                        });
                });

            modelBuilder.Entity("Carsalesbyhoho.Models.Klant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contactgegevens")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("Carsalesbyhoho.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gebruikersnaam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("GeregistreerdOp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Carsalesbyhoho.Models.Verkoop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AutoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Betaald")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("TEXT");

                    b.Property<int>("KlantId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AutoId");

                    b.HasIndex("KlantId");

                    b.ToTable("Verkopen");
                });

            modelBuilder.Entity("Carsalesbyhoho.Models.Auto", b =>
                {
                    b.HasOne("Carsalesbyhoho.Models.AutoType", "AutoType")
                        .WithMany("Autos")
                        .HasForeignKey("AutoTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Carsalesbyhoho.Models.Brand", "Brand")
                        .WithMany("Autos")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutoType");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Carsalesbyhoho.Models.Verkoop", b =>
                {
                    b.HasOne("Carsalesbyhoho.Models.Auto", "Auto")
                        .WithMany("Verkopen")
                        .HasForeignKey("AutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Carsalesbyhoho.Models.Klant", "Klant")
                        .WithMany("Verkopen")
                        .HasForeignKey("KlantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auto");

                    b.Navigation("Klant");
                });

            modelBuilder.Entity("Carsalesbyhoho.Models.Auto", b =>
                {
                    b.Navigation("Verkopen");
                });

            modelBuilder.Entity("Carsalesbyhoho.Models.AutoType", b =>
                {
                    b.Navigation("Autos");
                });

            modelBuilder.Entity("Carsalesbyhoho.Models.Brand", b =>
                {
                    b.Navigation("Autos");
                });

            modelBuilder.Entity("Carsalesbyhoho.Models.Klant", b =>
                {
                    b.Navigation("Verkopen");
                });
#pragma warning restore 612, 618
        }
    }
}
