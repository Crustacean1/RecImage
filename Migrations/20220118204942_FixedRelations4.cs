﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class FixedRelations4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 49, 42, 487, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 49, 42, 487, DateTimeKind.Local).AddTicks(801));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 49, 42, 487, DateTimeKind.Local).AddTicks(804));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}