using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorBuddy_MCsoft.Migrations
{
    public partial class Initialt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModuleCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModuleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LevelOfStudy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentNumber);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    StudentNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Approved = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Fee = table.Column<double>(type: "double", nullable: false),
                    AvgRating = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.StudentNumber);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Link = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModuleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Resources_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModulesTutored",
                columns: table => new
                {
                    StudentNumber = table.Column<int>(type: "int", nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulesTutored", x => new { x.StudentNumber, x.ModuleID });
                    table.ForeignKey(
                        name: "FK_ModulesTutored_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModulesTutored_Tutors_StudentNumber",
                        column: x => x.StudentNumber,
                        principalTable: "Tutors",
                        principalColumn: "StudentNumber",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<double>(type: "double", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StudentNumber = table.Column<int>(type: "int", nullable: true),
                    TutorStudentNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Student_StudentNumber",
                        column: x => x.StudentNumber,
                        principalTable: "Student",
                        principalColumn: "StudentNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Tutors_TutorStudentNumber",
                        column: x => x.TutorStudentNumber,
                        principalTable: "Tutors",
                        principalColumn: "StudentNumber",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SessionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AmountOfPeople = table.Column<int>(type: "int", nullable: false),
                    ModuleTutorStudentNumber = table.Column<int>(type: "int", nullable: true),
                    ModuleTutorModuleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionID);
                    table.ForeignKey(
                        name: "FK_Sessions_ModulesTutored_ModuleTutorStudentNumber_ModuleTutor~",
                        columns: x => new { x.ModuleTutorStudentNumber, x.ModuleTutorModuleID },
                        principalTable: "ModulesTutored",
                        principalColumns: new[] { "StudentNumber", "ModuleID" },
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "IndividualBookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Paid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SessionID = table.Column<int>(type: "int", nullable: true),
                    StudentNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualBookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_IndividualBookings_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "SessionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualBookings_Student_StudentNumber",
                        column: x => x.StudentNumber,
                        principalTable: "Student",
                        principalColumn: "StudentNumber",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentGroupBooking",
                columns: table => new
                {
                    StudentNumber = table.Column<int>(type: "int", nullable: false),
                    BookingID = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_StudentGroupBooking_Student_StudentNumber",
                        column: x => x.StudentNumber,
                        principalTable: "Student",
                        principalColumn: "StudentNumber",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GroupBooking_SessionID",
                table: "GroupBooking",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualBookings_SessionID",
                table: "IndividualBookings",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualBookings_StudentNumber",
                table: "IndividualBookings",
                column: "StudentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_ModulesTutored_ModuleID",
                table: "ModulesTutored",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ModuleID",
                table: "Resources",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_StudentNumber",
                table: "Reviews",
                column: "StudentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TutorStudentNumber",
                table: "Reviews",
                column: "TutorStudentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ModuleTutorStudentNumber_ModuleTutorModuleID",
                table: "Sessions",
                columns: new[] { "ModuleTutorStudentNumber", "ModuleTutorModuleID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroupBooking_BookingID",
                table: "StudentGroupBooking",
                column: "BookingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualBookings");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "StudentGroupBooking");

            migrationBuilder.DropTable(
                name: "GroupBooking");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "ModulesTutored");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Tutors");
        }
    }
}
