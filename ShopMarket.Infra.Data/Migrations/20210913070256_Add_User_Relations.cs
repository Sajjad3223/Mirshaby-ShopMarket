using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopMarket.Infra.Data.Migrations
{
    public partial class Add_User_Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedProduct_Products_ProductId",
                table: "LikedProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_LikedProduct_Users_UserId",
                table: "LikedProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserAdress_ReceiveAddressAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_RecentVisit_Products_ProductId",
                table: "RecentVisit");

            migrationBuilder.DropForeignKey(
                name: "FK_RecentVisit_Users_UserId",
                table: "RecentVisit");

            migrationBuilder.DropTable(
                name: "UserAdress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecentVisit",
                table: "RecentVisit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedProduct",
                table: "LikedProduct");

            migrationBuilder.RenameTable(
                name: "RecentVisit",
                newName: "RecentVisits");

            migrationBuilder.RenameTable(
                name: "LikedProduct",
                newName: "LikedProducts");

            migrationBuilder.RenameIndex(
                name: "IX_RecentVisit_UserId",
                table: "RecentVisits",
                newName: "IX_RecentVisits_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecentVisit_ProductId",
                table: "RecentVisits",
                newName: "IX_RecentVisits_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LikedProduct_UserId",
                table: "LikedProducts",
                newName: "IX_LikedProducts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LikedProduct_ProductId",
                table: "LikedProducts",
                newName: "IX_LikedProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecentVisits",
                table: "RecentVisits",
                column: "RecentVisitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedProducts",
                table: "LikedProducts",
                column: "LikedProductId");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Plaque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedProducts_Products_ProductId",
                table: "LikedProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikedProducts_Users_UserId",
                table: "LikedProducts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_ReceiveAddressAddressId",
                table: "Orders",
                column: "ReceiveAddressAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecentVisits_Products_ProductId",
                table: "RecentVisits",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecentVisits_Users_UserId",
                table: "RecentVisits",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedProducts_Products_ProductId",
                table: "LikedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_LikedProducts_Users_UserId",
                table: "LikedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_ReceiveAddressAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_RecentVisits_Products_ProductId",
                table: "RecentVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_RecentVisits_Users_UserId",
                table: "RecentVisits");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecentVisits",
                table: "RecentVisits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedProducts",
                table: "LikedProducts");

            migrationBuilder.RenameTable(
                name: "RecentVisits",
                newName: "RecentVisit");

            migrationBuilder.RenameTable(
                name: "LikedProducts",
                newName: "LikedProduct");

            migrationBuilder.RenameIndex(
                name: "IX_RecentVisits_UserId",
                table: "RecentVisit",
                newName: "IX_RecentVisit_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RecentVisits_ProductId",
                table: "RecentVisit",
                newName: "IX_RecentVisit_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_LikedProducts_UserId",
                table: "LikedProduct",
                newName: "IX_LikedProduct_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LikedProducts_ProductId",
                table: "LikedProduct",
                newName: "IX_LikedProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecentVisit",
                table: "RecentVisit",
                column: "RecentVisitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedProduct",
                table: "LikedProduct",
                column: "LikedProductId");

            migrationBuilder.CreateTable(
                name: "UserAdress",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Plaque = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdress", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_UserAdress_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAdress_UserId",
                table: "UserAdress",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedProduct_Products_ProductId",
                table: "LikedProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikedProduct_Users_UserId",
                table: "LikedProduct",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserAdress_ReceiveAddressAddressId",
                table: "Orders",
                column: "ReceiveAddressAddressId",
                principalTable: "UserAdress",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecentVisit_Products_ProductId",
                table: "RecentVisit",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecentVisit_Users_UserId",
                table: "RecentVisit",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
