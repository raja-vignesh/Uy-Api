using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Restaurants.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KiloCalories",
                table: "dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "dishes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KiloCalories",
                table: "dishes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "dishes");
        }
    }
}
