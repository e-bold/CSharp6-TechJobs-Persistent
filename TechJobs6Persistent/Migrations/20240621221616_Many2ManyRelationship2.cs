using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechJobs6Persistent.Migrations
{
    public partial class Many2ManyRelationship2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkill_Jobs_JobsId",
                table: "JobSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkill_Skills_SkillsId",
                table: "JobSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSkill",
                table: "JobSkill");

            migrationBuilder.RenameTable(
                name: "JobSkill",
                newName: "jobskill");

            migrationBuilder.RenameIndex(
                name: "IX_JobSkill_SkillsId",
                table: "jobskill",
                newName: "IX_jobskill_SkillsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobskill",
                table: "jobskill",
                columns: new[] { "JobsId", "SkillsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_jobskill_Jobs_JobsId",
                table: "jobskill",
                column: "JobsId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobskill_Skills_SkillsId",
                table: "jobskill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobskill_Jobs_JobsId",
                table: "jobskill");

            migrationBuilder.DropForeignKey(
                name: "FK_jobskill_Skills_SkillsId",
                table: "jobskill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobskill",
                table: "jobskill");

            migrationBuilder.RenameTable(
                name: "jobskill",
                newName: "JobSkill");

            migrationBuilder.RenameIndex(
                name: "IX_jobskill_SkillsId",
                table: "JobSkill",
                newName: "IX_JobSkill_SkillsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSkill",
                table: "JobSkill",
                columns: new[] { "JobsId", "SkillsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkill_Jobs_JobsId",
                table: "JobSkill",
                column: "JobsId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkill_Skills_SkillsId",
                table: "JobSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
