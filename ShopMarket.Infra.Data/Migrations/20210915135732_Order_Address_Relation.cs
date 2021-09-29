using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopMarket.Infra.Data.Migrations
{
    public partial class Order_Address_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_ReceiveAddressAddressId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ReceiveAddressAddressId",
                table: "Orders",
                newName: "ReceiveAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ReceiveAddressAddressId",
                table: "Orders",
                newName: "IX_Orders_ReceiveAddressId");

            migrationBuilder.AddColumn<int>(
                name: "ReceiverAddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_ReceiveAddressId",
                table: "Orders",
                column: "ReceiveAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_ReceiveAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverAddressId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ReceiveAddressId",
                table: "Orders",
                newName: "ReceiveAddressAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ReceiveAddressId",
                table: "Orders",
                newName: "IX_Orders_ReceiveAddressAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_ReceiveAddressAddressId",
                table: "Orders",
                column: "ReceiveAddressAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
