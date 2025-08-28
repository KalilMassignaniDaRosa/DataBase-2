using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnoescBank.Migrations
{
    /// <inheritdoc />
    public partial class Linq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Account");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
