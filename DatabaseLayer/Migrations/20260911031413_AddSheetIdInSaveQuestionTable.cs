using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddSheetIdInSaveQuestionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SheetId",
                table: "saveQuestions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_saveQuestions_SheetId",
                table: "saveQuestions",
                column: "SheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_saveQuestions_sheets_SheetId",
                table: "saveQuestions",
                column: "SheetId",
                principalTable: "sheets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_saveQuestions_sheets_SheetId",
                table: "saveQuestions");

            migrationBuilder.DropIndex(
                name: "IX_saveQuestions_SheetId",
                table: "saveQuestions");

            migrationBuilder.DropColumn(
                name: "SheetId",
                table: "saveQuestions");
        }
    }
}
