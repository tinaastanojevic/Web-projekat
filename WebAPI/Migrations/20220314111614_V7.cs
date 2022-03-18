using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Autori_AutorID",
                table: "Knjige");

            migrationBuilder.RenameColumn(
                name: "AutorID",
                table: "Knjige",
                newName: "AutorKnjigeID");

            migrationBuilder.RenameIndex(
                name: "IX_Knjige_AutorID",
                table: "Knjige",
                newName: "IX_Knjige_AutorKnjigeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Autori_AutorKnjigeID",
                table: "Knjige",
                column: "AutorKnjigeID",
                principalTable: "Autori",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Autori_AutorKnjigeID",
                table: "Knjige");

            migrationBuilder.RenameColumn(
                name: "AutorKnjigeID",
                table: "Knjige",
                newName: "AutorID");

            migrationBuilder.RenameIndex(
                name: "IX_Knjige_AutorKnjigeID",
                table: "Knjige",
                newName: "IX_Knjige_AutorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Autori_AutorID",
                table: "Knjige",
                column: "AutorID",
                principalTable: "Autori",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
