using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class nullableQuestionDependId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_questions_QuestionDependId",
                table: "questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionDependId",
                table: "questions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_questions_QuestionDependId",
                table: "questions",
                column: "QuestionDependId",
                principalTable: "questions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_questions_QuestionDependId",
                table: "questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionDependId",
                table: "questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_questions_QuestionDependId",
                table: "questions",
                column: "QuestionDependId",
                principalTable: "questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
