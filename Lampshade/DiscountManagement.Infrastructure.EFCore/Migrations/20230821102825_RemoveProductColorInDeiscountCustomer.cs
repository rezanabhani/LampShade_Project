using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountManagement.Infrastructure.EFCore.Migrations
{
    public partial class RemoveProductColorInDeiscountCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "CustomerDiscounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductColorId",
                table: "CustomerDiscounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
