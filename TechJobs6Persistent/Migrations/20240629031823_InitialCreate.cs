using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechJobs6Persistent.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Jobs_JobsId",
                table: "JobSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSkills_Skills_SkillsId",
                table: "JobSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobSkills",
                table: "JobSkills");

            migrationBuilder.RenameTable(
                name: "JobSkills",
                newName: "JobSkill");

            migrationBuilder.RenameIndex(
                name: "IX_JobSkills_SkillsId",
                table: "JobSkill",
                newName: "IX_JobSkill_SkillsId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Skills",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Jobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "JobSkills");

            migrationBuilder.RenameIndex(
                name: "IX_JobSkill_SkillsId",
                table: "JobSkills",
                newName: "IX_JobSkills_SkillsId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Skills",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Jobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobSkills",
                table: "JobSkills",
                columns: new[] { "JobsId", "SkillsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Jobs_JobsId",
                table: "JobSkills",
                column: "JobsId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSkills_Skills_SkillsId",
                table: "JobSkills",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
