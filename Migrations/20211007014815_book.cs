using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorBuddy_MCsoft.Migrations
{
    public partial class book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupBooking_Sessions_SessionID",
                table: "GroupBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroupBooking_GroupBooking_BookingID",
                table: "StudentGroupBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupBooking",
                table: "GroupBooking");

            migrationBuilder.RenameTable(
                name: "GroupBooking",
                newName: "GroupBookings");

            migrationBuilder.RenameIndex(
                name: "IX_GroupBooking_SessionID",
                table: "GroupBookings",
                newName: "IX_GroupBookings_SessionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupBookings",
                table: "GroupBookings",
                column: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupBookings_Sessions_SessionID",
                table: "GroupBookings",
                column: "SessionID",
                principalTable: "Sessions",
                principalColumn: "SessionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroupBooking_GroupBookings_BookingID",
                table: "StudentGroupBooking",
                column: "BookingID",
                principalTable: "GroupBookings",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupBookings_Sessions_SessionID",
                table: "GroupBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentGroupBooking_GroupBookings_BookingID",
                table: "StudentGroupBooking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupBookings",
                table: "GroupBookings");

            migrationBuilder.RenameTable(
                name: "GroupBookings",
                newName: "GroupBooking");

            migrationBuilder.RenameIndex(
                name: "IX_GroupBookings_SessionID",
                table: "GroupBooking",
                newName: "IX_GroupBooking_SessionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupBooking",
                table: "GroupBooking",
                column: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupBooking_Sessions_SessionID",
                table: "GroupBooking",
                column: "SessionID",
                principalTable: "Sessions",
                principalColumn: "SessionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentGroupBooking_GroupBooking_BookingID",
                table: "StudentGroupBooking",
                column: "BookingID",
                principalTable: "GroupBooking",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
