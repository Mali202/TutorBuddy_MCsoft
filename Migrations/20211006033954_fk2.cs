using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorBuddy_MCsoft.Migrations
{
    public partial class fk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroupBooking_Student_StudentNumber1",
                table: "StudentGroupBooking");

            migrationBuilder.DropIndex(
                name: "IX_StudentGroupBooking_StudentNumber1",
                table: "StudentGroupBooking");

            migrationBuilder.DropColumn(
                name: "StudentNumber1",
                table: "StudentGroupBooking");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroupBooking_Student_StudentNumber",
                table: "StudentGroupBooking",
                column: "StudentNumber",
                principalTable: "Student",
                principalColumn: "StudentNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroupBooking_Student_StudentNumber",
                table: "StudentGroupBooking");

            migrationBuilder.AddColumn<int>(
                name: "StudentNumber1",
                table: "StudentGroupBooking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroupBooking_StudentNumber1",
                table: "StudentGroupBooking",
                column: "StudentNumber1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroupBooking_Student_StudentNumber1",
                table: "StudentGroupBooking",
                column: "StudentNumber1",
                principalTable: "Student",
                principalColumn: "StudentNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
