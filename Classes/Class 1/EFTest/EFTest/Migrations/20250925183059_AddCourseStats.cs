using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFTest.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Course",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSemesters",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageFrequency",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "AverageGrade",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "NumberOfSemesters",
                table: "Course");
        }
    }
}
