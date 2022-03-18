using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autori",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autori", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clanovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanovi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Knjige",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Godina = table.Column<int>(type: "int", nullable: false),
                    BrojStrana = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knjige", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Iznajmljivanja",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iznajmljivanja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Iznajmljivanja_Clanovi_ClanID",
                        column: x => x.ClanID,
                        principalTable: "Clanovi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutorKnjiga",
                columns: table => new
                {
                    AutoriID = table.Column<int>(type: "int", nullable: false),
                    KnjigeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorKnjiga", x => new { x.AutoriID, x.KnjigeID });
                    table.ForeignKey(
                        name: "FK_AutorKnjiga_Autori_AutoriID",
                        column: x => x.AutoriID,
                        principalTable: "Autori",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorKnjiga_Knjige_KnjigeID",
                        column: x => x.KnjigeID,
                        principalTable: "Knjige",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_AutorKnjiga_KnjigeID",
                table: "AutorKnjiga",
                column: "KnjigeID");

            migrationBuilder.CreateIndex(
                name: "IX_Iznajmljivanja_ClanID",
                table: "Iznajmljivanja",
                column: "ClanID");

            migrationBuilder.CreateIndex(
                name: "IX_IznajmljivanjeKnjiga_KnjigeID",
                table: "IznajmljivanjeKnjiga",
                column: "KnjigeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorKnjiga");

            migrationBuilder.DropTable(
                name: "IznajmljivanjeKnjiga");

            migrationBuilder.DropTable(
                name: "Autori");

            migrationBuilder.DropTable(
                name: "Iznajmljivanja");

            migrationBuilder.DropTable(
                name: "Knjige");

            migrationBuilder.DropTable(
                name: "Clanovi");
        }
    }
}
