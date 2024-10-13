using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmallClinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_AdmissionStatus_AdmissionStatusId",
                table: "Admissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdmissionLines",
                table: "AdmissionLines");

            migrationBuilder.DropColumn(
                name: "StartingValue",
                table: "SequenceNumbers");

            migrationBuilder.AddColumn<Guid>(
                name: "AdmissionId",
                table: "SequenceNumbers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EntityID",
                table: "SequenceNumbers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "GenderId",
                table: "Genders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SequenceId",
                table: "Admissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdmissionStatusId",
                table: "AdmissionLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdmissionLines",
                table: "AdmissionLines",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("80180f43-4f47-4390-992e-a9905bb5faeb"), "Male", false, "Male" },
                    { new Guid("80743f3b-f685-44a9-bb8f-79d5fea26d0d"), "FeMale", false, "FeMale" },
                    { new Guid("ff4e105a-db7a-40cb-8ce2-d5832d757785"), "Other", false, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SequenceNumbers_AdmissionId",
                table: "SequenceNumbers",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_SequenceId",
                table: "Admissions",
                column: "SequenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionLines_AdmissionId",
                table: "AdmissionLines",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionLines_AdmissionStatusId",
                table: "AdmissionLines",
                column: "AdmissionStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionLines_AdmissionStatus_AdmissionStatusId",
                table: "AdmissionLines",
                column: "AdmissionStatusId",
                principalTable: "AdmissionStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_AdmissionStatus_AdmissionStatusId",
                table: "Admissions",
                column: "AdmissionStatusId",
                principalTable: "AdmissionStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_SequenceNumbers_SequenceId",
                table: "Admissions",
                column: "SequenceId",
                principalTable: "SequenceNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SequenceNumbers_Admissions_AdmissionId",
                table: "SequenceNumbers",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionLines_AdmissionStatus_AdmissionStatusId",
                table: "AdmissionLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_AdmissionStatus_AdmissionStatusId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_SequenceNumbers_SequenceId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_SequenceNumbers_Admissions_AdmissionId",
                table: "SequenceNumbers");

            migrationBuilder.DropIndex(
                name: "IX_SequenceNumbers_AdmissionId",
                table: "SequenceNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_SequenceId",
                table: "Admissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdmissionLines",
                table: "AdmissionLines");

            migrationBuilder.DropIndex(
                name: "IX_AdmissionLines_AdmissionId",
                table: "AdmissionLines");

            migrationBuilder.DropIndex(
                name: "IX_AdmissionLines_AdmissionStatusId",
                table: "AdmissionLines");

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("80180f43-4f47-4390-992e-a9905bb5faeb"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("80743f3b-f685-44a9-bb8f-79d5fea26d0d"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("ff4e105a-db7a-40cb-8ce2-d5832d757785"));

            migrationBuilder.DropColumn(
                name: "AdmissionId",
                table: "SequenceNumbers");

            migrationBuilder.DropColumn(
                name: "EntityID",
                table: "SequenceNumbers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "SequenceId",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "AdmissionStatusId",
                table: "AdmissionLines");

            migrationBuilder.AddColumn<int>(
                name: "StartingValue",
                table: "SequenceNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdmissionLines",
                table: "AdmissionLines",
                columns: new[] { "AdmissionId", "ServiceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_AdmissionStatus_AdmissionStatusId",
                table: "Admissions",
                column: "AdmissionStatusId",
                principalTable: "AdmissionStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
