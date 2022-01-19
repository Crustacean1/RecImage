using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class FixedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "MetaId",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 5, 40, 569, DateTimeKind.Local).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "MetaId",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 5, 40, 569, DateTimeKind.Local).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "MetaId",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 5, 40, 569, DateTimeKind.Local).AddTicks(8603));
        }
    }
}
