using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopMarket.Infra.Data.Migrations
{
    public partial class add_showinslider_property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowInMainPage",
                table: "ShopCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowInSlider",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowInMainPage",
                table: "ShopCategories");

            migrationBuilder.DropColumn(
                name: "ShowInSlider",
                table: "Products");
        }
    }
}
