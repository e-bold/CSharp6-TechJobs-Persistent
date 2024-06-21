using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechJobs6Persistent.Migrations
{
    public partial class Task2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployerId",
                table: "Employers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employers_EmployerId",
                table: "Employers",
                column: "EmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employers_Employers_EmployerId",
                table: "Employers",
                column: "EmployerId",
                principalTable: "Employers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employers_Employers_EmployerId",
                table: "Employers");

            migrationBuilder.DropIndex(
                name: "IX_Employers_EmployerId",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "EmployerId",
                table: "Employers");
        }
    }
}
