using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWT_test.Migrations
{
    public partial class Update_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Subject",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Student",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subject",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "StudentId");
        }
    }
}
