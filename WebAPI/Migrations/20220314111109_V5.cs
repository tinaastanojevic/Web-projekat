using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorKnjiga");

            migrationBuilder.AddColumn<int>(
                name: "AutorID",
                table: "Knjige",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Knjige_AutorID",
                table: "Knjige",
                column: "AutorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Knjige_Autori_AutorID",
                table: "Knjige",
                column: "AutorID",
                principalTable: "Autori",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Knjige_Autori_AutorID",
                table: "Knjige");

            migrationBuilder.DropIndex(
                name: "IX_Knjige_AutorID",
                table: "Knjige");

            migrationBuilder.DropColumn(
                name: "AutorID",
                table: "Knjige");

            migrationBuilder.DropColumn(
                name: "IDBiblioteke",
                table: "Knjige");

            migrationBuilder.DropColumn(
                name: "IDBiblioteke",
                table: "Clanovi");

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

            migrationBuilder.CreateIndex(
                name: "IX_AutorKnjiga_KnjigeID",
                table: "AutorKnjiga",
                column: "KnjigeID");
        }
    }
}
