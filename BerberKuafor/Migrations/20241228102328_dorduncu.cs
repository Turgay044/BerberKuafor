using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BerberKuafor.Migrations
{
    /// <inheritdoc />
    public partial class dorduncu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KullaniciMail",
                table: "Admins",
                type: "Varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciMail",
                table: "Admins");
        }
    }
}
