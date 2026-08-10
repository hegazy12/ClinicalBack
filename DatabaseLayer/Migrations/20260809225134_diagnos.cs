using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class diagnos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VitalSign_AspNetUsers_CreatedBy",
                table: "VitalSign");

            migrationBuilder.DropForeignKey(
                name: "FK_VitalSign_AspNetUsers_DeletedBy",
                table: "VitalSign");

            migrationBuilder.DropForeignKey(
                name: "FK_VitalSign_AspNetUsers_UpdatedBy",
                table: "VitalSign");

            migrationBuilder.DropForeignKey(
                name: "FK_VitalSign_appointments_AppointmentId",
                table: "VitalSign");

            migrationBuilder.DropForeignKey(
                name: "FK_VitalSign_vitalSignMasters_VitalSignMasterId",
                table: "VitalSign");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VitalSign",
                table: "VitalSign");

            migrationBuilder.RenameTable(
                name: "VitalSign",
                newName: "vitalSigns");

            migrationBuilder.RenameIndex(
                name: "IX_VitalSign_VitalSignMasterId",
                table: "vitalSigns",
                newName: "IX_vitalSigns_VitalSignMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_VitalSign_UpdatedBy",
                table: "vitalSigns",
                newName: "IX_vitalSigns_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_VitalSign_DeletedBy",
                table: "vitalSigns",
                newName: "IX_vitalSigns_DeletedBy");

            migrationBuilder.RenameIndex(
                name: "IX_VitalSign_CreatedBy",
                table: "vitalSigns",
                newName: "IX_vitalSigns_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_VitalSign_AppointmentId",
                table: "vitalSigns",
                newName: "IX_vitalSigns_AppointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vitalSigns",
                table: "vitalSigns",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "diagnos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiagnosMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_diagnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_diagnos_AspNetUsers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_diagnos_AspNetUsers_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_diagnos_AspNetUsers_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_diagnos_DiagnosMaster_DiagnosMasterId",
                        column: x => x.DiagnosMasterId,
                        principalTable: "DiagnosMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_diagnos_appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_diagnos_AppointmentId",
                table: "diagnos",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_diagnos_CreatedBy",
                table: "diagnos",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_diagnos_DeletedBy",
                table: "diagnos",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_diagnos_DiagnosMasterId",
                table: "diagnos",
                column: "DiagnosMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_diagnos_UpdatedBy",
                table: "diagnos",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_vitalSigns_AspNetUsers_CreatedBy",
                table: "vitalSigns",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vitalSigns_AspNetUsers_DeletedBy",
                table: "vitalSigns",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vitalSigns_AspNetUsers_UpdatedBy",
                table: "vitalSigns",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vitalSigns_appointments_AppointmentId",
                table: "vitalSigns",
                column: "AppointmentId",
                principalTable: "appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vitalSigns_vitalSignMasters_VitalSignMasterId",
                table: "vitalSigns",
                column: "VitalSignMasterId",
                principalTable: "vitalSignMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vitalSigns_AspNetUsers_CreatedBy",
                table: "vitalSigns");

            migrationBuilder.DropForeignKey(
                name: "FK_vitalSigns_AspNetUsers_DeletedBy",
                table: "vitalSigns");

            migrationBuilder.DropForeignKey(
                name: "FK_vitalSigns_AspNetUsers_UpdatedBy",
                table: "vitalSigns");

            migrationBuilder.DropForeignKey(
                name: "FK_vitalSigns_appointments_AppointmentId",
                table: "vitalSigns");

            migrationBuilder.DropForeignKey(
                name: "FK_vitalSigns_vitalSignMasters_VitalSignMasterId",
                table: "vitalSigns");

            migrationBuilder.DropTable(
                name: "diagnos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vitalSigns",
                table: "vitalSigns");

            migrationBuilder.RenameTable(
                name: "vitalSigns",
                newName: "VitalSign");

            migrationBuilder.RenameIndex(
                name: "IX_vitalSigns_VitalSignMasterId",
                table: "VitalSign",
                newName: "IX_VitalSign_VitalSignMasterId");

            migrationBuilder.RenameIndex(
                name: "IX_vitalSigns_UpdatedBy",
                table: "VitalSign",
                newName: "IX_VitalSign_UpdatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_vitalSigns_DeletedBy",
                table: "VitalSign",
                newName: "IX_VitalSign_DeletedBy");

            migrationBuilder.RenameIndex(
                name: "IX_vitalSigns_CreatedBy",
                table: "VitalSign",
                newName: "IX_VitalSign_CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_vitalSigns_AppointmentId",
                table: "VitalSign",
                newName: "IX_VitalSign_AppointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VitalSign",
                table: "VitalSign",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VitalSign_AspNetUsers_CreatedBy",
                table: "VitalSign",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VitalSign_AspNetUsers_DeletedBy",
                table: "VitalSign",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VitalSign_AspNetUsers_UpdatedBy",
                table: "VitalSign",
                column: "UpdatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VitalSign_appointments_AppointmentId",
                table: "VitalSign",
                column: "AppointmentId",
                principalTable: "appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VitalSign_vitalSignMasters_VitalSignMasterId",
                table: "VitalSign",
                column: "VitalSignMasterId",
                principalTable: "vitalSignMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
