using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class FixedRelations3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 41, 42, 615, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 41, 42, 615, DateTimeKind.Local).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 41, 42, 615, DateTimeKind.Local).AddTicks(3092));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 39, 54, 400, DateTimeKind.Local).AddTicks(9421));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 39, 54, 400, DateTimeKind.Local).AddTicks(9455));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 39, 54, 400, DateTimeKind.Local).AddTicks(9460));
        }
    }
}
