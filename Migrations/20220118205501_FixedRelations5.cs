using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class FixedRelations5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaData_Users_UserId",
                table: "MetaData");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MetaData",
                newName: "ImageUserId");

            migrationBuilder.RenameIndex(
                name: "IX_MetaData_UserId",
                table: "MetaData",
                newName: "IX_MetaData_ImageUserId");

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 55, 0, 892, DateTimeKind.Local).AddTicks(3805));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 21, 55, 0, 892, DateTimeKind.Local).AddTicks(3839));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Creation", "ImageUserId" },
                values: new object[] { new DateTime(2022, 1, 18, 21, 55, 0, 892, DateTimeKind.Local).AddTicks(3842), 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_MetaData_Users_ImageUserId",
                table: "MetaData",
                column: "ImageUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaData_Users_ImageUserId",
                table: "MetaData");

            migrationBuilder.RenameColumn(
                name: "ImageUserId",
                table: "MetaData",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MetaData_ImageUserId",
                table: "MetaData",
                newName: "IX_MetaData_UserId");

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
                columns: new[] { "Creation", "UserId" },
                values: new object[] { new DateTime(2022, 1, 18, 21, 49, 42, 487, DateTimeKind.Local).AddTicks(804), 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_MetaData_Users_UserId",
                table: "MetaData",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
