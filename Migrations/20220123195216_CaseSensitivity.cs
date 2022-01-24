using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecImage.Migrations
{
    public partial class CaseSensitivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                collation: "latin1_general_cs",
                oldCollation: "latin_1_general_cs");

            migrationBuilder.AlterTable(
                name: "Users")
                .Annotation("Relational:Collation", "latin1_general_cs")
                .OldAnnotation("Relational:Collation", "latin_1_general_cs");

            migrationBuilder.AlterTable(
                name: "ImageInfo")
                .Annotation("Relational:Collation", "latin1_general_cs")
                .OldAnnotation("Relational:Collation", "latin_1_general_cs");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "longtext",
                nullable: true,
                collation: "latin1_general_cs",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "latin_1_general_cs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ImageInfo",
                type: "longtext",
                nullable: true,
                collation: "latin1_general_cs",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "latin_1_general_cs");

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                table: "ImageInfo",
                type: "longtext",
                nullable: true,
                collation: "latin1_general_cs",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "latin_1_general_cs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                collation: "latin_1_general_cs",
                oldCollation: "latin1_general_cs");

            migrationBuilder.AlterTable(
                name: "Users")
                .Annotation("Relational:Collation", "latin_1_general_cs")
                .OldAnnotation("Relational:Collation", "latin1_general_cs");

            migrationBuilder.AlterTable(
                name: "ImageInfo")
                .Annotation("Relational:Collation", "latin_1_general_cs")
                .OldAnnotation("Relational:Collation", "latin1_general_cs");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "longtext",
                nullable: true,
                collation: "latin_1_general_cs",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "latin1_general_cs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ImageInfo",
                type: "longtext",
                nullable: true,
                collation: "latin_1_general_cs",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "latin1_general_cs");

            migrationBuilder.AlterColumn<string>(
                name: "Extension",
                table: "ImageInfo",
                type: "longtext",
                nullable: true,
                collation: "latin_1_general_cs",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "latin1_general_cs");
        }
    }
}
