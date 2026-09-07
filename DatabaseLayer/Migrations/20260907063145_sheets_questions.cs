using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class sheets_questions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdated = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sheets_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_sheets_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_sheets_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SheetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maxValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    minValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requeried = table.Column<bool>(type: "bit", nullable: false),
                    listValues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionDependId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdated = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_questions_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_questions_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_questions_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_questions_questions_QuestionDependId",
                        column: x => x.QuestionDependId,
                        principalTable: "questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_questions_sheets_SheetId",
                        column: x => x.SheetId,
                        principalTable: "sheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "saveQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUpdated = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saveQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_saveQuestions_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_saveQuestions_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_saveQuestions_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_saveQuestions_appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_saveQuestions_questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_questions_CreatedBy",
                table: "questions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_questions_DeletedBy",
                table: "questions",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_questions_QuestionDependId",
                table: "questions",
                column: "QuestionDependId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_SheetId",
                table: "questions",
                column: "SheetId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_UpdatedBy",
                table: "questions",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_saveQuestions_AppointmentId",
                table: "saveQuestions",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_saveQuestions_CreatedBy",
                table: "saveQuestions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_saveQuestions_DeletedBy",
                table: "saveQuestions",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_saveQuestions_QuestionId",
                table: "saveQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_saveQuestions_UpdatedBy",
                table: "saveQuestions",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_sheets_CreatedBy",
                table: "sheets",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_sheets_DeletedBy",
                table: "sheets",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_sheets_UpdatedBy",
                table: "sheets",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "saveQuestions");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "sheets");
        }
    }
}
