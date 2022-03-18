using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IznajmljivanjeKnjiga");

            migrationBuilder.AddColumn<int>(
                name: "BibliotekaID",
                table: "Knjige",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KnjigaClanID",
                table: "Knjige",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BibliotekaID",
                table: "Clanovi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Biblioteke",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblioteke", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_BibliotekaID",
                table: "Knjige",
                column: "BibliotekaID");

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_KnjigaClanID",
                table: "Knjige",
                column: "KnjigaClanID");

            migrationBuilder.CreateIndex(
                name: "IX_Clanovi_BibliotekaID",
                table: "Clanovi",
                column: "BibliotekaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clanovi_Biblioteke_BibliotekaID",
                table: "Clanovi",
                column: "BibliotekaID",
                principalTable: "Biblioteke",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Biblioteke_BibliotekaID",
                table: "Knjige",
                column: "BibliotekaID",
                principalTable: "Biblioteke",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Iznajmljivanja_KnjigaClanID",
                table: "Knjige",
                column: "KnjigaClanID",
                principalTable: "Iznajmljivanja",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clanovi_Biblioteke_BibliotekaID",
                table: "Clanovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Biblioteke_BibliotekaID",
                table: "Knjige");

            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Iznajmljivanja_KnjigaClanID",
                table: "Knjige");

            migrationBuilder.DropTable(
                name: "Biblioteke");

            migrationBuilder.DropIndex(
                name: "IX_Knjige_BibliotekaID",
                table: "Knjige");

            migrationBuilder.DropIndex(
                name: "IX_Knjige_KnjigaClanID",
                table: "Knjige");

            migrationBuilder.DropIndex(
                name: "IX_Clanovi_BibliotekaID",
                table: "Clanovi");

            migrationBuilder.DropColumn(
                name: "BibliotekaID",
                table: "Knjige");

            migrationBuilder.DropColumn(
                name: "KnjigaClanID",
                table: "Knjige");

            migrationBuilder.DropColumn(
                name: "BibliotekaID",
                table: "Clanovi");

            migrationBuilder.CreateTable(
                name: "IznajmljivanjeKnjiga",
                columns: table => new
                {
                    IznajmljivanjaID = table.Column<int>(type: "int", nullable: false),
                    KnjigeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IznajmljivanjeKnjiga", x => new { x.IznajmljivanjaID, x.KnjigeID });
                    table.ForeignKey(
                        name: "FK_IznajmljivanjeKnjiga_Iznajmljivanja_IznajmljivanjaID",
                        column: x => x.IznajmljivanjaID,
                        principalTable: "Iznajmljivanja",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IznajmljivanjeKnjiga_Knjige_KnjigeID",
                        column: x => x.KnjigeID,
                        principalTable: "Knjige",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IznajmljivanjeKnjiga_KnjigeID",
                table: "IznajmljivanjeKnjiga",
                column: "KnjigeID");
        }
    }
}
