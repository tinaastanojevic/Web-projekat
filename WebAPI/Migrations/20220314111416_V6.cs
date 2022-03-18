using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDBiblioteke",
                table: "Knjige");

            migrationBuilder.DropColumn(
                name: "IDBiblioteke",
                table: "Clanovi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDBiblioteke",
                table: "Knjige",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDBiblioteke",
                table: "Clanovi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
