using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carsalesbyhoho.Migrations
{
    /// <inheritdoc />
    public partial class RenameMerkToBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Merken_MerkId",
                table: "Autos");

            migrationBuilder.DropTable(
                name: "Merken");

            migrationBuilder.DropIndex(
                name: "IX_Autos_MerkId",
                table: "Autos");

            migrationBuilder.AddColumn<string>(
                name: "AfbeeldingUrl",
                table: "Autos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Autos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Gebruikersnaam = table.Column<string>(type: "TEXT", nullable: false),
                    Wachtwoord = table.Column<string>(type: "TEXT", nullable: false),
                    Rol = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_BrandId",
                table: "Autos",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Brands_BrandId",
                table: "Autos",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Brands_BrandId",
                table: "Autos");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Autos_BrandId",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "AfbeeldingUrl",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Autos");

            migrationBuilder.CreateTable(
                name: "Merken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merken", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_MerkId",
                table: "Autos",
                column: "MerkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Merken_MerkId",
                table: "Autos",
                column: "MerkId",
                principalTable: "Merken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
