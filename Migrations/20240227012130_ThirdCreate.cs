using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BangazonServer.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct");

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderProduct",
                keyColumn: "Id",
                keyColumnType: "integer",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderProduct",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderProduct",
                newName: "OrdersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct",
                columns: new[] { "OrdersId", "ProductsId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_OrdersId",
                table: "OrderProduct",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductsId",
                table: "OrderProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_OrdersId",
                table: "OrderProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductsId",
                table: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_ProductsId",
                table: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "OrderProduct",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "OrderProduct",
                newName: "OrderId");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderProduct",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProduct",
                table: "OrderProduct",
                column: "Id");

            migrationBuilder.InsertData(
                table: "OrderProduct",
                columns: new[] { "Id", "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 1 },
                    { 3, 2, 5 },
                    { 4, 3, 4 },
                    { 5, 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
