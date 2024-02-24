using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BangazonServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IsVendor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    VendorId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Users_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ShippingRequired = table.Column<bool>(type: "boolean", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, "Visual Artwork", null },
                    { 2, "Textile", null },
                    { 3, "Gifts", null }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Visa" },
                    { 2, "MasterCard" },
                    { 3, "Amex" },
                    { 4, "Paypal" },
                    { 5, "Discover" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsVendor", "LastName", "Uid", "Username" },
                values: new object[,]
                {
                    { 1, "myemail@gmail.com", "Maggie", false, "Chafee", "judi73nv90p89", "magsbags" },
                    { 2, "natalie.m@me.com", "Natalie", true, "Mays", "sdii73n390p89", "lucky_stars_stitches" },
                    { 3, "jayrude@yahoo.com", "Jason", false, "Peterson", "cXdi4knv90p45", "jayRude88" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "DateCreated", "IsCompleted", "OrderId", "PaymentTypeId", "ProductId", "ShippingRequired" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, 2, null, false },
                    { 2, 2, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, 3, null, false },
                    { 3, 1, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, 1, null, false },
                    { 4, 1, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, 5, null, false },
                    { 5, 1, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, 4, null, false }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "IsAvailable", "Name", "Price", "VendorId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It is a painting of the sea.", true, "Seascape Painting", 250.00m, 3 },
                    { 2, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It is a charcoal drawing of a flower.", true, "Orchid Charcoal Drawing", 150.00m, 3 },
                    { 3, 2, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Embroidered Teacup", false, "Teacup Felt Embroidery", 50.00m, 2 },
                    { 4, 2, new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Choose Your Own Adventure", true, "Custom Denim Jacket Embroidery", 100.00m, 2 },
                    { 5, 1, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "A charcoal drawing of an iris.", false, "Iris Charcoal Drawing", 100.00m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductId",
                table: "Categories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderId",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendorId",
                table: "Products",
                column: "VendorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
