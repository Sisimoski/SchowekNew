using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchowekAPI.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "Items",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "Items",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Items",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Items",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemColor",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Catalogs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "CatalogColor",
                table: "Catalogs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Catalogs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Catalogs",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemColor",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CatalogColor",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Catalogs");

            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Catalogs",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
