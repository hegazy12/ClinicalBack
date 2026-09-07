using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseLayer.Migrations
{
    /// <inheritdoc />
    public partial class vitalsighModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_saveVitalSigns_vitalSignMasters_VitalSignId",
                table: "saveVitalSigns");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "saveExamination",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_saveVitalSigns_vitalSigns_VitalSignId",
                table: "saveVitalSigns",
                column: "VitalSignId",
                principalTable: "vitalSigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_saveVitalSigns_vitalSigns_VitalSignId",
                table: "saveVitalSigns");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "saveExamination",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_saveVitalSigns_vitalSignMasters_VitalSignId",
                table: "saveVitalSigns",
                column: "VitalSignId",
                principalTable: "vitalSignMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
