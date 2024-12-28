using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerberKuafor.Migrations
{
    /// <inheritdoc />
    public partial class birinci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    IDPersonel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.IDPersonel);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    IdMusteri = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personIDPersonel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.IdMusteri);
                    table.ForeignKey(
                        name: "FK_Musteriler_Personels_personIDPersonel",
                        column: x => x.personIDPersonel,
                        principalTable: "Personels",
                        principalColumn: "IDPersonel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_personIDPersonel",
                table: "Musteriler",
                column: "personIDPersonel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropTable(
                name: "Personels");
        }
    }
}
