using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MetaData",
                columns: table => new
                {
                    MetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OriginalFile = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModifiedFile = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ImageHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaData", x => x.MetaId);
                    table.ForeignKey(
                        name: "FK_MetaData_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login" },
                values: new object[] { 1, "kamil@crustacean.pl" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Login" },
                values: new object[] { 2, "limak@naecatsurc.lp" });

            migrationBuilder.InsertData(
                table: "MetaData",
                columns: new[] { "MetaId", "Creation", "ImageHash", "ModifiedFile", "OriginalFile", "OwnerId" },
                values: new object[] { 1, new DateTime(2022, 1, 18, 19, 45, 40, 269, DateTimeKind.Local).AddTicks(6362), "hashhashhash", "cockroach_shop.jpg", "ladybug_shop.jpg", 1 });

            migrationBuilder.InsertData(
                table: "MetaData",
                columns: new[] { "MetaId", "Creation", "ImageHash", "ModifiedFile", "OriginalFile", "OwnerId" },
                values: new object[] { 2, new DateTime(2022, 1, 18, 19, 45, 40, 269, DateTimeKind.Local).AddTicks(6415), "hashhashhash", "duck_shop.jpg", "frog_shop.jpg", 1 });

            migrationBuilder.InsertData(
                table: "MetaData",
                columns: new[] { "MetaId", "Creation", "ImageHash", "ModifiedFile", "OriginalFile", "OwnerId" },
                values: new object[] { 3, new DateTime(2022, 1, 18, 19, 45, 40, 269, DateTimeKind.Local).AddTicks(6420), "hashhashhash", "pepe_the_duck.jpg", "pepe_the_frog.jpg", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_MetaData_OwnerId",
                table: "MetaData",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetaData");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
