using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class FinalVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(type: "longtext", nullable: true, collation: "latin1_general_cs")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("Relational:Collation", "latin1_general_cs");

            migrationBuilder.CreateTable(
                name: "ImageInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true, collation: "latin1_general_cs"),
                    Extension = table.Column<string>(type: "longtext", nullable: true, collation: "latin1_general_cs"),
                    ImageUserId = table.Column<int>(type: "int", nullable: false),
                    CurrentTransformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageInfo_Users_ImageUserId",
                        column: x => x.ImageUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("Relational:Collation", "latin1_general_cs");

            migrationBuilder.CreateTable(
                name: "Transforms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImageInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transforms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transforms_ImageInfo_ImageInfoId",
                        column: x => x.ImageInfoId,
                        principalTable: "ImageInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("Relational:Collation", "latin1_general_cs");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login" },
                values: new object[] { 1, "kamil@crustacean.pl" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login" },
                values: new object[] { 2, "limak@naecatsurc.lp" });

            migrationBuilder.CreateIndex(
                name: "IX_ImageInfo_CurrentTransformId",
                table: "ImageInfo",
                column: "CurrentTransformId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageInfo_ImageUserId",
                table: "ImageInfo",
                column: "ImageUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transforms_ImageInfoId",
                table: "Transforms",
                column: "ImageInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageInfo_Transforms_CurrentTransformId",
                table: "ImageInfo",
                column: "CurrentTransformId",
                principalTable: "Transforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageInfo_Transforms_CurrentTransformId",
                table: "ImageInfo");

            migrationBuilder.DropTable(
                name: "Transforms");

            migrationBuilder.DropTable(
                name: "ImageInfo");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
