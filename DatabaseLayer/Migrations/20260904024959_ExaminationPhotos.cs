using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class ExaminationPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExaminationPhotos",
                table: "saveExamination");

            migrationBuilder.CreateTable(
                name: "saveExaminationPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    examinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    photoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photoBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_saveExaminationPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_saveExaminationPhotos_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_saveExaminationPhotos_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_saveExaminationPhotos_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_saveExaminationPhotos_saveExamination_examinationId",
                        column: x => x.examinationId,
                        principalTable: "saveExamination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_saveExaminationPhotos_CreatedBy",
                table: "saveExaminationPhotos",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_saveExaminationPhotos_DeletedBy",
                table: "saveExaminationPhotos",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_saveExaminationPhotos_examinationId",
                table: "saveExaminationPhotos",
                column: "examinationId");

            migrationBuilder.CreateIndex(
                name: "IX_saveExaminationPhotos_UpdatedBy",
                table: "saveExaminationPhotos",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "saveExaminationPhotos");

            migrationBuilder.AddColumn<string>(
                name: "ExaminationPhotos",
                table: "saveExamination",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
