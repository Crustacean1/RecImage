using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class ImageInfoRevision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUploaded",
                table: "ImageInfo",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2022, 1, 20, 18, 23, 29, 686, DateTimeKind.Local).AddTicks(9613));

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2022, 1, 20, 18, 23, 29, 686, DateTimeKind.Local).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2022, 1, 20, 18, 23, 29, 686, DateTimeKind.Local).AddTicks(9651));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUploaded",
                table: "ImageInfo");

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2022, 1, 20, 17, 41, 4, 809, DateTimeKind.Local).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2022, 1, 20, 17, 41, 4, 809, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "ImageInfo",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2022, 1, 20, 17, 41, 4, 809, DateTimeKind.Local).AddTicks(8914));
        }
    }
}
