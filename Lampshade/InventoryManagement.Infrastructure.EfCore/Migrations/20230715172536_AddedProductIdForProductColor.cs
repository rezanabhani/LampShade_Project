using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.EfCore.Migrations
{
    public partial class AddedProductIdForProductColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "ProductColors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductColors");
        }
    }
}
