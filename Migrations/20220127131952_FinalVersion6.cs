using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class FinalVersion6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageInfo_Transforms_CurrentTransformId",
                table: "ImageInfo");

            migrationBuilder.DropIndex(
                name: "IX_ImageInfo_CurrentTransformId",
                table: "ImageInfo");

            migrationBuilder.DropColumn(
                name: "CurrentTransformId",
                table: "ImageInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentTransformId",
                table: "ImageInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ImageInfo_CurrentTransformId",
                table: "ImageInfo",
                column: "CurrentTransformId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageInfo_Transforms_CurrentTransformId",
                table: "ImageInfo",
                column: "CurrentTransformId",
                principalTable: "Transforms",
                principalColumn: "Id");
        }
    }
}
