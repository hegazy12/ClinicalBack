using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class saveExaminationID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_saveExamination_medicalExaminations_Examination",
                table: "saveExamination");

            migrationBuilder.RenameColumn(
                name: "Examination",
                table: "saveExamination",
                newName: "ExaminationId");

            migrationBuilder.RenameIndex(
                name: "IX_saveExamination_Examination",
                table: "saveExamination",
                newName: "IX_saveExamination_ExaminationId");

            migrationBuilder.AddForeignKey(
                name: "FK_saveExamination_medicalExaminations_ExaminationId",
                table: "saveExamination",
                column: "ExaminationId",
                principalTable: "medicalExaminations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_saveExamination_medicalExaminations_ExaminationId",
                table: "saveExamination");

            migrationBuilder.RenameColumn(
                name: "ExaminationId",
                table: "saveExamination",
                newName: "Examination");

            migrationBuilder.RenameIndex(
                name: "IX_saveExamination_ExaminationId",
                table: "saveExamination",
                newName: "IX_saveExamination_Examination");

            migrationBuilder.AddForeignKey(
                name: "FK_saveExamination_medicalExaminations_Examination",
                table: "saveExamination",
                column: "Examination",
                principalTable: "medicalExaminations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
