using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorBuddy_MCsoft.Migrations
{
    public partial class bookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModulesTutored_Tutors_TutorStudentNumber",
                table: "ModulesTutored");

            migrationBuilder.DropIndex(
                name: "IX_ModulesTutored_TutorStudentNumber",
                table: "ModulesTutored");

            migrationBuilder.DropColumn(
                name: "TutorStudentNumber",
                table: "ModulesTutored");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Sessions",
                newName: "SessionID");

            migrationBuilder.AddColumn<int>(
                name: "ModuleTutorModuleCode",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModuleTutorStudentNumber",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupBooking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Paid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SessionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupBooking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_GroupBooking_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "SessionID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentGroupBooking",
                columns: table => new
                {
                    StudentNumber = table.Column<int>(type: "int", nullable: false),
                    BookingID = table.Column<int>(type: "int", nullable: false),
                    StudentNumber1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroupBooking", x => new { x.StudentNumber, x.BookingID });
                    table.ForeignKey(
                        name: "FK_StudentGroupBooking_GroupBooking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "GroupBooking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGroupBooking_Student_StudentNumber1",
                        column: x => x.StudentNumber1,
                        principalTable: "Student",
                        principalColumn: "StudentNumber",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ModuleTutorStudentNumber_ModuleTutorModuleCode",
                table: "Sessions",
                columns: new[] { "ModuleTutorStudentNumber", "ModuleTutorModuleCode" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupBooking_SessionID",
                table: "GroupBooking",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroupBooking_BookingID",
                table: "StudentGroupBooking",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroupBooking_StudentNumber1",
                table: "StudentGroupBooking",
                column: "StudentNumber1");

            migrationBuilder.AddForeignKey(
                name: "FK_ModulesTutored_Tutors_StudentNumber",
                table: "ModulesTutored",
                column: "StudentNumber",
                principalTable: "Tutors",
                principalColumn: "StudentNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_ModulesTutored_ModuleTutorStudentNumber_ModuleTutor~",
                table: "Sessions",
                columns: new[] { "ModuleTutorStudentNumber", "ModuleTutorModuleCode" },
                principalTable: "ModulesTutored",
                principalColumns: new[] { "StudentNumber", "ModuleCode" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModulesTutored_Tutors_StudentNumber",
                table: "ModulesTutored");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_ModulesTutored_ModuleTutorStudentNumber_ModuleTutor~",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "StudentGroupBooking");

            migrationBuilder.DropTable(
                name: "GroupBooking");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_ModuleTutorStudentNumber_ModuleTutorModuleCode",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "ModuleTutorModuleCode",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "ModuleTutorStudentNumber",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "SessionID",
                table: "Sessions",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "TutorStudentNumber",
                table: "ModulesTutored",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModulesTutored_TutorStudentNumber",
                table: "ModulesTutored",
                column: "TutorStudentNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_ModulesTutored_Tutors_TutorStudentNumber",
                table: "ModulesTutored",
                column: "TutorStudentNumber",
                principalTable: "Tutors",
                principalColumn: "StudentNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
