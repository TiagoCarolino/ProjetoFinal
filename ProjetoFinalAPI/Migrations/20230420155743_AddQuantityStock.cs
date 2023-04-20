using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinalAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Units",
                table: "Stocks",
                newName: "Quantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Stocks",
                newName: "Units");
        }
    }
}
