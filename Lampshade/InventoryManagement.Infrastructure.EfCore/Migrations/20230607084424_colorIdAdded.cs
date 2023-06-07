using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.EfCore.Migrations
{
    public partial class colorIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ColorId",
                table: "Inventory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProductColorId",
                table: "Inventory",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductColorId",
                table: "Inventory",
                column: "ProductColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_ProductColors_ProductColorId",
                table: "Inventory",
                column: "ProductColorId",
                principalTable: "ProductColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_ProductColors_ProductColorId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ProductColorId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "Inventory");
        }
    }
}
