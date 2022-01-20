using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class ImageInfoRenaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedFile",
                table: "ImageInfo");

            migrationBuilder.RenameColumn(
                name: "OriginalFile",
                table: "ImageInfo",
                newName: "Extension");

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Creation", "Extension" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 41, 4, 809, DateTimeKind.Local).AddTicks(8879), "jpg" });

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Creation", "Extension" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 41, 4, 809, DateTimeKind.Local).AddTicks(8911), "jpg" });

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "Extension", "Name" },
                values: new object[] { new DateTime(2022, 1, 20, 17, 41, 4, 809, DateTimeKind.Local).AddTicks(8914), "jpg", "pepe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Extension",
                table: "ImageInfo",
                newName: "OriginalFile");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedFile",
                table: "ImageInfo",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Creation", "ModifiedFile", "OriginalFile" },
                values: new object[] { new DateTime(2022, 1, 19, 21, 19, 32, 299, DateTimeKind.Local).AddTicks(4308), "cockroach_shop.jpg", "ladybug_shop.jpg" });

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Creation", "ModifiedFile", "OriginalFile" },
                values: new object[] { new DateTime(2022, 1, 19, 21, 19, 32, 299, DateTimeKind.Local).AddTicks(4340), "duck_shop.jpg", "frog_shop.jpg" });

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "ModifiedFile", "Name", "OriginalFile" },
                values: new object[] { new DateTime(2022, 1, 19, 21, 19, 32, 299, DateTimeKind.Local).AddTicks(4344), "pepe_the_duck.jpg", "4chan", "pepe_the_frog.jpg" });
        }
    }
}
