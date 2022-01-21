using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class ImageInfoReduction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creation",
                table: "ImageInfo");

            migrationBuilder.DropColumn(
                name: "ImageHash",
                table: "ImageInfo");

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "Extension",
                value: null);

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 2,
                column: "Extension",
                value: null);

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 3,
                column: "Extension",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Creation",
                table: "ImageInfo",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImageHash",
                table: "ImageInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Creation", "Extension", "ImageHash" },
                values: new object[] { new DateTime(2022, 1, 20, 18, 23, 29, 686, DateTimeKind.Local).AddTicks(9613), "jpg", "hashhashhash" });

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Creation", "Extension", "ImageHash" },
                values: new object[] { new DateTime(2022, 1, 20, 18, 23, 29, 686, DateTimeKind.Local).AddTicks(9648), "jpg", "hashhashhash" });

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "Extension", "ImageHash" },
                values: new object[] { new DateTime(2022, 1, 20, 18, 23, 29, 686, DateTimeKind.Local).AddTicks(9651), "jpg", "hashhashhash" });
        }
    }
}
