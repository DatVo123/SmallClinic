using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmallClinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionLines_Admissions_AdmissionId",
                table: "AdmissionLines");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionLines_Services_ServiceId",
                table: "AdmissionLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Genders_GenderId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialities_SpecialityId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Genders_GenderId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_AdmissionStatusId",
                table: "Admissions");

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("013ea0bd-440a-463b-b475-7ec8f7918e06"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("949935d3-8e0b-4b32-9d0b-e9f680c39035"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("aa6e61b3-a7af-4c4f-bdd2-310cfc8c19ff"));

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Admissions",
                newName: "CreateDate");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "AdmissionAmount",
                table: "Admissions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("4ba20b13-e619-4137-816b-96e8950b5e4b"), "Other", false, "Other" },
                    { new Guid("67ec75fb-cfb4-422f-a19f-8d313941387c"), "FeMale", false, "FeMale" },
                    { new Guid("91cff332-0739-434a-9e63-3f911b25d24d"), "Male", false, "Male" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_AdmissionStatusId",
                table: "Admissions",
                column: "AdmissionStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionLines_Admissions_AdmissionId",
                table: "AdmissionLines",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionLines_Services_ServiceId",
                table: "AdmissionLines",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Genders_GenderId",
                table: "Doctors",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialities_SpecialityId",
                table: "Doctors",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Genders_GenderId",
                table: "Patients",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionLines_Admissions_AdmissionId",
                table: "AdmissionLines");

            migrationBuilder.DropForeignKey(
                name: "FK_AdmissionLines_Services_ServiceId",
                table: "AdmissionLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Genders_GenderId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialities_SpecialityId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Genders_GenderId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_AdmissionStatusId",
                table: "Admissions");

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4ba20b13-e619-4137-816b-96e8950b5e4b"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("67ec75fb-cfb4-422f-a19f-8d313941387c"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("91cff332-0739-434a-9e63-3f911b25d24d"));

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AdmissionAmount",
                table: "Admissions");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Admissions",
                newName: "DateTime");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("013ea0bd-440a-463b-b475-7ec8f7918e06"), "Male", false, "Male" },
                    { new Guid("949935d3-8e0b-4b32-9d0b-e9f680c39035"), "Other", false, "Other" },
                    { new Guid("aa6e61b3-a7af-4c4f-bdd2-310cfc8c19ff"), "FeMale", false, "FeMale" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_AdmissionStatusId",
                table: "Admissions",
                column: "AdmissionStatusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionLines_Admissions_AdmissionId",
                table: "AdmissionLines",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdmissionLines_Services_ServiceId",
                table: "AdmissionLines",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Genders_GenderId",
                table: "Doctors",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialities_SpecialityId",
                table: "Doctors",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Genders_GenderId",
                table: "Patients",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
