using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerberKuafor.Migrations
{
    /// <inheritdoc />
    public partial class ikinci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_Personels_personIDPersonel",
                table: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Musteriler_personIDPersonel",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "personIDPersonel",
                table: "Musteriler");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "personIDPersonel",
                table: "Musteriler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_personIDPersonel",
                table: "Musteriler",
                column: "personIDPersonel");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_Personels_personIDPersonel",
                table: "Musteriler",
                column: "personIDPersonel",
                principalTable: "Personels",
                principalColumn: "IDPersonel",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
