using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class ImageInfoTweaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsUploaded",
                table: "ImageInfo",
                newName: "IsTransformed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsTransformed",
                table: "ImageInfo",
                newName: "IsUploaded");
        }
    }
}
