using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFTest.Migrations
{
    /// <inheritdoc />
    public partial class CourseFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageFrequency",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "AverageGrade",
                table: "Course");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AverageFrequency",
                table: "Course",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AverageGrade",
                table: "Course",
                type: "float",
                nullable: true);
        }
    }
}
