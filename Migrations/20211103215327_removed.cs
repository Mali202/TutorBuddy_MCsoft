using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorBuddy_MCsoft.Migrations
{
    public partial class removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentGroupBooking");

            migrationBuilder.DropTable(
                name: "GroupBookings");

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HolderName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BankName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccNumber = table.Column<int>(type: "int", nullable: false),
                    Ref = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.CreateTable(
                name: "GroupBookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Paid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SessionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupBookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_GroupBookings_Sessions_SessionID",
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
                    BookingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroupBooking", x => new { x.StudentNumber, x.BookingID });
                    table.ForeignKey(
                        name: "FK_StudentGroupBooking_GroupBookings_BookingID",
                        column: x => x.BookingID,
                        principalTable: "GroupBookings",
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
                name: "IX_GroupBookings_SessionID",
                table: "GroupBookings",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroupBooking_BookingID",
                table: "StudentGroupBooking",
                column: "BookingID");
        }
    }
}
