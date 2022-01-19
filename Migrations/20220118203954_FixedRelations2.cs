using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class FixedRelations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetaId",
                table: "MetaData",
                newName: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MetaData",
                newName: "MetaId");

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "MetaId",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 36, 38, 5, DateTimeKind.Local).AddTicks(7108));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "MetaId",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 36, 38, 5, DateTimeKind.Local).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "MetaId",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 36, 38, 5, DateTimeKind.Local).AddTicks(7146));
        }
    }
}
