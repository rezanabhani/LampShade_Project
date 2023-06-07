using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Infrastructure.EfCore.Migrations
{
    public partial class ColorIdChangedToProductColorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_ProductColors_ProductColorId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Inventory");

            migrationBuilder.AlterColumn<long>(
                name: "ProductColorId",
                table: "Inventory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_ProductColors_ProductColorId",
                table: "Inventory",
                column: "ProductColorId",
                principalTable: "ProductColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_ProductColors_ProductColorId",
                table: "Inventory");

            migrationBuilder.AlterColumn<long>(
                name: "ProductColorId",
                table: "Inventory",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ColorId",
                table: "Inventory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_ProductColors_ProductColorId",
                table: "Inventory",
                column: "ProductColorId",
                principalTable: "ProductColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
