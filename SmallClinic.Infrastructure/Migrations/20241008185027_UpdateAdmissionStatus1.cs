using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallClinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdmissionStatus1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_admissionStatus_AdmissionStatusId",
                table: "Admissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_admissionStatus",
                table: "admissionStatus");

            migrationBuilder.RenameTable(
                name: "admissionStatus",
                newName: "AdmissionStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdmissionStatus",
                table: "AdmissionStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_AdmissionStatus_AdmissionStatusId",
                table: "Admissions",
                column: "AdmissionStatusId",
                principalTable: "AdmissionStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_AdmissionStatus_AdmissionStatusId",
                table: "Admissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdmissionStatus",
                table: "AdmissionStatus");

            migrationBuilder.RenameTable(
                name: "AdmissionStatus",
                newName: "admissionStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admissionStatus",
                table: "admissionStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_admissionStatus_AdmissionStatusId",
                table: "Admissions",
                column: "AdmissionStatusId",
                principalTable: "admissionStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
