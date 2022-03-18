using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Iznajmljivanja_KnjigaClanID",
                table: "Knjige");

            migrationBuilder.DropIndex(
                name: "IX_Knjige_KnjigaClanID",
                table: "Knjige");

            migrationBuilder.DropColumn(
                name: "KnjigaClanID",
                table: "Knjige");

            migrationBuilder.AddColumn<int>(
                name: "KnjigeID",
                table: "Iznajmljivanja",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanja_KnjigeID",
                table: "Iznajmljivanja",
                column: "KnjigeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Iznajmljivanja_Knjige_KnjigeID",
                table: "Iznajmljivanja",
                column: "KnjigeID",
                principalTable: "Knjige",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iznajmljivanja_Knjige_KnjigeID",
                table: "Iznajmljivanja");

            migrationBuilder.DropIndex(
                name: "IX_Iznajmljivanja_KnjigeID",
                table: "Iznajmljivanja");

            migrationBuilder.DropColumn(
                name: "KnjigeID",
                table: "Iznajmljivanja");

            migrationBuilder.AddColumn<int>(
                name: "KnjigaClanID",
                table: "Knjige",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_KnjigaClanID",
                table: "Knjige",
                column: "KnjigaClanID");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Iznajmljivanja_KnjigaClanID",
                table: "Knjige",
                column: "KnjigaClanID",
                principalTable: "Iznajmljivanja",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
