using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallClinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdmissionStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdmissionStatusId",
                table: "Admissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "admissionStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admissionStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_AdmissionStatusId",
                table: "Admissions",
                column: "AdmissionStatusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_admissionStatus_AdmissionStatusId",
                table: "Admissions",
                column: "AdmissionStatusId",
                principalTable: "admissionStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_admissionStatus_AdmissionStatusId",
                table: "Admissions");

            migrationBuilder.DropTable(
                name: "admissionStatus");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_AdmissionStatusId",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "AdmissionStatusId",
                table: "Admissions");
        }
    }
}
