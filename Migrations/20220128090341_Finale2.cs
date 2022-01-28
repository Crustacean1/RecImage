using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class Finale2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login" },
                values: new object[] { 1, "kamil@crustacean.pl" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login" },
                values: new object[] { 2, "limak@naecatsurc.lp" });
        }
    }
}
