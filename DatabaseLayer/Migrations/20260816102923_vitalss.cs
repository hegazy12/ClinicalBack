using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class vitalss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vitalSigns_appointments_AppointmentId",
                table: "vitalSigns");

            migrationBuilder.DropIndex(
                name: "IX_vitalSigns_AppointmentId",
                table: "vitalSigns");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "vitalSigns");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "vitalSigns",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "dataTypeName",
                table: "vitalSigns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "vitalSigns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "listValues",
                table: "vitalSigns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "maxValue",
                table: "vitalSigns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "minValue",
                table: "vitalSigns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataTypeName",
                table: "vitalSigns");

            migrationBuilder.DropColumn(
                name: "description",
                table: "vitalSigns");

            migrationBuilder.DropColumn(
                name: "listValues",
                table: "vitalSigns");

            migrationBuilder.DropColumn(
                name: "maxValue",
                table: "vitalSigns");

            migrationBuilder.DropColumn(
                name: "minValue",
                table: "vitalSigns");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "vitalSigns",
                newName: "Value");

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "vitalSigns",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_vitalSigns_AppointmentId",
                table: "vitalSigns",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_vitalSigns_appointments_AppointmentId",
                table: "vitalSigns",
                column: "AppointmentId",
                principalTable: "appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
