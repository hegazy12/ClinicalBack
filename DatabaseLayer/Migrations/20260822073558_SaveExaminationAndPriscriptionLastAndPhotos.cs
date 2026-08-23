using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class SaveExaminationAndPriscriptionLastAndPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExaminationPhotos",
                table: "saveExamination",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "last",
                table: "saveExamination",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "last",
                table: "prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExaminationPhotos",
                table: "saveExamination");

            migrationBuilder.DropColumn(
                name: "last",
                table: "saveExamination");

            migrationBuilder.DropColumn(
                name: "last",
                table: "prescriptions");
        }
    }
}
