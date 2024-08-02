using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademicRecordsApp.Migrations
{
    public partial class Courses_Exam_Rel_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ExamId",
                table: "Courses",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Exams_ExamId",
                table: "Courses",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Exams_ExamId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ExamId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Courses");
        }
    }
}
