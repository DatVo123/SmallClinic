using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmallClinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "EntityID",
                table: "SequenceNumbers");

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("a90dd0e8-b071-4d2b-96d0-65c021ae6c98"), "FeMale", false, "FeMale" },
                    { new Guid("ae16350a-867c-46e3-9ca7-08d352be7c40"), "Male", false, "Male" },
                    { new Guid("ee979224-efb2-43d6-9acb-f5ec22c3df84"), "Other", false, "Other" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "EntityID",
                table: "SequenceNumbers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("80180f43-4f47-4390-992e-a9905bb5faeb"), "Male", false, "Male" },
                    { new Guid("80743f3b-f685-44a9-bb8f-79d5fea26d0d"), "FeMale", false, "FeMale" },
                    { new Guid("ff4e105a-db7a-40cb-8ce2-d5832d757785"), "Other", false, "Other" }
                });
        }
    }
}
