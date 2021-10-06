using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorBuddy_MCsoft.Migrations.Identity
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentNumber",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "AspNetUsers");
        }
    }
}
