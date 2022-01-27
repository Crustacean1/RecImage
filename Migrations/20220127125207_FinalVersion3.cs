using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class FinalVersion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageInfo_Transforms_CurrentTransformId",
                table: "ImageInfo");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageInfo_Transforms_CurrentTransformId",
                table: "ImageInfo",
                column: "CurrentTransformId",
                principalTable: "Transforms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageInfo_Transforms_CurrentTransformId",
                table: "ImageInfo");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageInfo_Transforms_CurrentTransformId",
                table: "ImageInfo",
                column: "CurrentTransformId",
                principalTable: "Transforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
