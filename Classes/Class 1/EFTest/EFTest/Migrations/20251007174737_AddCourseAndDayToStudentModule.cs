using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFTest.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseAndDayToStudentModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentModule",
                table: "StudentModule");

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "StudentModule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "StudentModule",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentModule",
                table: "StudentModule",
                columns: new[] { "StudentID", "ModuleID", "CourseID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentModule_CourseID",
                table: "StudentModule",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentModule_Course_CourseID",
                table: "StudentModule",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentModule_Course_CourseID",
                table: "StudentModule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentModule",
                table: "StudentModule");

            migrationBuilder.DropIndex(
                name: "IX_StudentModule_CourseID",
                table: "StudentModule");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "StudentModule");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "StudentModule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentModule",
                table: "StudentModule",
                columns: new[] { "StudentID", "ModuleID" });
        }
    }
}
