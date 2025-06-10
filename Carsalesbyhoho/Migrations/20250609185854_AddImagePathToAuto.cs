using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carsalesbyhoho.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathToAuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Autos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Autos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Autos");
        }
    }
}
