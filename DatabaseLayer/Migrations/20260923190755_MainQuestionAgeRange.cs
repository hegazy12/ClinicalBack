using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class MainQuestionAgeRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "age",
                table: "mainQuestions",
                newName: "minage");

            migrationBuilder.AddColumn<int>(
                name: "maxage",
                table: "mainQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maxage",
                table: "mainQuestions");

            migrationBuilder.RenameColumn(
                name: "minage",
                table: "mainQuestions",
                newName: "age");
        }
    }
}
