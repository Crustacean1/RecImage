using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class TableRevision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetaData");

            migrationBuilder.CreateTable(
                name: "ImageInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginalFile = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedFile = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ImageHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUserId = table.Column<int>(type: "int", nullable: false)
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ImageInfo",
                columns: new[] { "Id", "Creation", "ImageHash", "ImageUserId", "ModifiedFile", "Name", "OriginalFile" },
                values: new object[] { 1, new DateTime(2022, 1, 19, 21, 19, 32, 299, DateTimeKind.Local).AddTicks(4308), "hashhashhash", 1, "cockroach_shop.jpg", "ladybug", "ladybug_shop.jpg" });

            migrationBuilder.InsertData(
                table: "ImageInfo",
                columns: new[] { "Id", "Creation", "ImageHash", "ImageUserId", "ModifiedFile", "Name", "OriginalFile" },
                values: new object[] { 2, new DateTime(2022, 1, 19, 21, 19, 32, 299, DateTimeKind.Local).AddTicks(4340), "hashhashhash", 1, "duck_shop.jpg", "frog", "frog_shop.jpg" });

            migrationBuilder.InsertData(
                table: "ImageInfo",
                columns: new[] { "Id", "Creation", "ImageHash", "ImageUserId", "ModifiedFile", "Name", "OriginalFile" },
                values: new object[] { 3, new DateTime(2022, 1, 19, 21, 19, 32, 299, DateTimeKind.Local).AddTicks(4344), "hashhashhash", 1, "pepe_the_duck.jpg", "4chan", "pepe_the_frog.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_ImageInfo_ImageUserId",
                table: "ImageInfo",
                column: "ImageUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageInfo");

            migrationBuilder.CreateTable(
                name: "MetaData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImageUserId = table.Column<int>(type: "int", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ImageHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedFile = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginalFile = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetaData_Users_ImageUserId",
                        column: x => x.ImageUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "MetaData",
                columns: new[] { "Id", "Creation", "ImageHash", "ImageUserId", "ModifiedFile", "OriginalFile" },
                values: new object[] { 1, new DateTime(2022, 1, 18, 21, 55, 0, 892, DateTimeKind.Local).AddTicks(3805), "hashhashhash", 1, "cockroach_shop.jpg", "ladybug_shop.jpg" });

            migrationBuilder.InsertData(
                table: "MetaData",
                columns: new[] { "Id", "Creation", "ImageHash", "ImageUserId", "ModifiedFile", "OriginalFile" },
                values: new object[] { 2, new DateTime(2022, 1, 18, 21, 55, 0, 892, DateTimeKind.Local).AddTicks(3839), "hashhashhash", 1, "duck_shop.jpg", "frog_shop.jpg" });

            migrationBuilder.InsertData(
                table: "MetaData",
                columns: new[] { "Id", "Creation", "ImageHash", "ImageUserId", "ModifiedFile", "OriginalFile" },
                values: new object[] { 3, new DateTime(2022, 1, 18, 21, 55, 0, 892, DateTimeKind.Local).AddTicks(3842), "hashhashhash", 1, "pepe_the_duck.jpg", "pepe_the_frog.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_MetaData_ImageUserId",
                table: "MetaData",
                column: "ImageUserId");
        }
    }
}
