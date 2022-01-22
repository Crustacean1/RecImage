using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class ImageInfoReduction2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ImageInfo",
                columns: new[] { "Id", "Extension", "ImageUserId", "IsUploaded", "Name" },
                values: new object[] { 1, null, 1, false, "ladybug" });

            migrationBuilder.InsertData(
                table: "ImageInfo",
                columns: new[] { "Id", "Extension", "ImageUserId", "IsUploaded", "Name" },
                values: new object[] { 2, null, 1, false, "frog" });

            migrationBuilder.InsertData(
                table: "ImageInfo",
                columns: new[] { "Id", "Extension", "ImageUserId", "IsUploaded", "Name" },
                values: new object[] { 3, null, 1, false, "pepe" });
        }
    }
}
