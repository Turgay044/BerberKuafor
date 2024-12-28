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
            migrationBuilder.AddColumn<string>(
                name: "AdminRole",
                table: "Admins",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminRole",
                table: "Admins");
        }
    }
}
