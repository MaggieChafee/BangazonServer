using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BangazonServer.Migrations
{
    public partial class FirebaseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: "xADM7ueUqUY7CPPNTjxpUQfgzNu2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Uid",
                value: "judi73nv90p89");
        }
    }
}
