using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Carsalesbyhoho.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Omschrijving = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Contactgegevens = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Gebruikersnaam = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Wachtwoord = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Rol = table.Column<string>(type: "TEXT", nullable: false),
                    GeregistreerdOp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Bouwjaar = table.Column<int>(type: "INTEGER", nullable: false),
                    Prijs = table.Column<decimal>(type: "TEXT", nullable: false),
                    Omschrijving = table.Column<string>(type: "TEXT", nullable: false),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    AutoTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    AfbeeldingUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autos_AutoTypes_AutoTypeId",
                        column: x => x.AutoTypeId,
                        principalTable: "AutoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autos_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Verkopen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AutoId = table.Column<int>(type: "INTEGER", nullable: false),
                    KlantId = table.Column<int>(type: "INTEGER", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Betaald = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verkopen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verkopen_Autos_AutoId",
                        column: x => x.AutoId,
                        principalTable: "Autos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verkopen_Klanten_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Klanten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AutoTypes",
                columns: new[] { "Id", "Omschrijving" },
                values: new object[,]
                {
                    { 1, "SUV" },
                    { 2, "Break" },
                    { 3, "Sedan" },
                    { 4, "Hatchback" },
                    { 5, "Cabriolet" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Naam" },
                values: new object[,]
                {
                    { 1, "Diesel" },
                    { 2, "Benzine" },
                    { 3, "Elektrisch" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_AutoTypeId",
                table: "Autos",
                column: "AutoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Autos_BrandId",
                table: "Autos",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Verkopen_AutoId",
                table: "Verkopen",
                column: "AutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Verkopen_KlantId",
                table: "Verkopen",
                column: "KlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Verkopen");

            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Klanten");

            migrationBuilder.DropTable(
                name: "AutoTypes");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
