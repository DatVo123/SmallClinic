using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmallClinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_SequenceNumbers_SequenceId",
                table: "Admissions");

            migrationBuilder.DropTable(
                name: "SequenceNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Admissions_SequenceId",
                table: "Admissions");

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("a90dd0e8-b071-4d2b-96d0-65c021ae6c98"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("ae16350a-867c-46e3-9ca7-08d352be7c40"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("ee979224-efb2-43d6-9acb-f5ec22c3df84"));

            migrationBuilder.DropColumn(
                name: "SequenceId",
                table: "Admissions");

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("013ea0bd-440a-463b-b475-7ec8f7918e06"), "Male", false, "Male" },
                    { new Guid("949935d3-8e0b-4b32-9d0b-e9f680c39035"), "Other", false, "Other" },
                    { new Guid("aa6e61b3-a7af-4c4f-bdd2-310cfc8c19ff"), "FeMale", false, "FeMale" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "SequenceId",
                table: "Admissions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SequenceNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentValue = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SequenceNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SequenceNumbers_Admissions_AdmissionId",
                        column: x => x.AdmissionId,
                        principalTable: "Admissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("a90dd0e8-b071-4d2b-96d0-65c021ae6c98"), "FeMale", false, "FeMale" },
                    { new Guid("ae16350a-867c-46e3-9ca7-08d352be7c40"), "Male", false, "Male" },
                    { new Guid("ee979224-efb2-43d6-9acb-f5ec22c3df84"), "Other", false, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_SequenceId",
                table: "Admissions",
                column: "SequenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SequenceNumbers_AdmissionId",
                table: "SequenceNumbers",
                column: "AdmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_SequenceNumbers_SequenceId",
                table: "Admissions",
                column: "SequenceId",
                principalTable: "SequenceNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
