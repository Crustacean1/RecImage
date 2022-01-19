using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class ChangedKeyNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaData_Users_OwnerId",
                table: "MetaData");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "MetaData",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MetaData_OwnerId",
                table: "MetaData",
                newName: "IX_MetaData_UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MetaData_Users_UserId",
                table: "MetaData",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MetaData_Users_UserId",
                table: "MetaData");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MetaData",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_MetaData_UserId",
                table: "MetaData",
                newName: "IX_MetaData_OwnerId");

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "MetaId",
                keyValue: 1,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 19, 45, 40, 269, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "MetaId",
                keyValue: 2,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 19, 45, 40, 269, DateTimeKind.Local).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "MetaData",
                keyColumn: "MetaId",
                keyValue: 3,
                column: "Creation",
                value: new DateTime(2022, 1, 18, 19, 45, 40, 269, DateTimeKind.Local).AddTicks(6420));

            migrationBuilder.AddForeignKey(
                name: "FK_MetaData_Users_OwnerId",
                table: "MetaData",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
