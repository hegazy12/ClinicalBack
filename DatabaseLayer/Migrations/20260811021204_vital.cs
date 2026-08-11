using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class vital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dose",
                table: "prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "classificationsMedicalExaminations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categoryAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryNameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_classificationsMedicalExaminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_classificationsMedicalExaminations_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_classificationsMedicalExaminations_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_classificationsMedicalExaminations_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "medicalExaminations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_medicalExaminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalExaminations_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_medicalExaminations_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_medicalExaminations_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_medicalExaminations_classificationsMedicalExaminations_classificationId",
                        column: x => x.classificationId,
                        principalTable: "classificationsMedicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classificationsMedicalExaminations_CreatedBy",
                table: "classificationsMedicalExaminations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_classificationsMedicalExaminations_DeletedBy",
                table: "classificationsMedicalExaminations",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_classificationsMedicalExaminations_UpdatedBy",
                table: "classificationsMedicalExaminations",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_medicalExaminations_classificationId",
                table: "medicalExaminations",
                column: "classificationId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalExaminations_CreatedBy",
                table: "medicalExaminations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_medicalExaminations_DeletedBy",
                table: "medicalExaminations",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_medicalExaminations_UpdatedBy",
                table: "medicalExaminations",
                column: "UpdatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicalExaminations");

            migrationBuilder.DropTable(
                name: "classificationsMedicalExaminations");

            migrationBuilder.DropColumn(
                name: "dose",
                table: "prescriptions");
        }
    }
}
