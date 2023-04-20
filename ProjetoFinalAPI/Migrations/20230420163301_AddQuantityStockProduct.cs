using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinalAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityStockProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityStock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityStock",
                table: "Products");
        }
    }
}
