using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carsalesbyhoho.Migrations
{
    /// <inheritdoc />
    public partial class FixAutoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MerkId",
                table: "Autos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MerkId",
                table: "Autos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
