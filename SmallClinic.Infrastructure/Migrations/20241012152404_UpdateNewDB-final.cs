using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmallClinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewDBfinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdmissionStatus",
                keyColumn: "Id",
                keyValue: new Guid("053ef800-fddc-401f-8fda-5549b1f628a2"));

            migrationBuilder.DeleteData(
                table: "AdmissionStatus",
                keyColumn: "Id",
                keyValue: new Guid("17ffc959-73cd-48f1-9802-3a13ac12c83d"));

            migrationBuilder.DeleteData(
                table: "AdmissionStatus",
                keyColumn: "Id",
                keyValue: new Guid("97cab86f-0db6-4601-9872-09d466c6b8ec"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("180056f3-f5b1-466c-9ab2-7db2d3001024"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("38db89a9-55fe-42ee-8cea-545de121c048"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("d1e8b66c-b1c9-4b59-a31a-b230e1c95baf"));

            migrationBuilder.DeleteData(
                table: "InvoicesStatus",
                keyColumn: "Id",
                keyValue: new Guid("0bc1933f-e857-424d-9fae-e9ee85d5678f"));

            migrationBuilder.DeleteData(
                table: "InvoicesStatus",
                keyColumn: "Id",
                keyValue: new Guid("2b0b1539-f814-4853-b1d2-76080af13b34"));

            migrationBuilder.DeleteData(
                table: "InvoicesStatus",
                keyColumn: "Id",
                keyValue: new Guid("93d2c4b6-1977-4808-98c3-83f732f60eaf"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Specialities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Services",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Promote",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "InvoicesStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "InvoicesLine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Genders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "AdmissionStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Admissions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "AdmissionLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AdmissionStatus",
                columns: new[] { "Id", "Code", "CreateDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("18b9ad46-c521-425a-a7b7-7c31ce516e31"), "Admitted", new DateTime(2024, 10, 12, 22, 24, 2, 837, DateTimeKind.Local).AddTicks(1977), false, "Đã đăng ký" },
                    { new Guid("2aa31e70-f7ce-4fa9-b6dc-247666f68852"), "Canclled", new DateTime(2024, 10, 12, 22, 24, 2, 837, DateTimeKind.Local).AddTicks(1991), false, "Đã hủy" },
                    { new Guid("c89e94d0-24cd-4af9-8854-80d9c915d0e6"), "Completed", new DateTime(2024, 10, 12, 22, 24, 2, 837, DateTimeKind.Local).AddTicks(1989), false, "Hoàn thành" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "CreateDate", "GenderId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("67fb44f9-dcd9-4f2b-a14c-ce0134772bb4"), new DateTime(2024, 10, 12, 22, 24, 2, 837, DateTimeKind.Local).AddTicks(2470), "Male", false, "Male" },
                    { new Guid("e973b196-96b3-4bae-97e0-73296ff51cbe"), new DateTime(2024, 10, 12, 22, 24, 2, 837, DateTimeKind.Local).AddTicks(2472), "FeMale", false, "FeMale" },
                    { new Guid("ff65847a-2482-44cf-95e2-082be86112e4"), new DateTime(2024, 10, 12, 22, 24, 2, 837, DateTimeKind.Local).AddTicks(2473), "Other", false, "Other" }
                });

            migrationBuilder.InsertData(
                table: "InvoicesStatus",
                columns: new[] { "Id", "Code", "CreateDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("86a2ec09-7f74-49cf-a75b-1e201cbe355c"), "Canclled", new DateTime(2024, 10, 12, 22, 24, 2, 837, DateTimeKind.Local).AddTicks(2437), false, "Đã hủy" },
                    { new Guid("cd142dd1-0c0d-4462-a7d4-2bb88f105d19"), "Paid", new DateTime(2024, 10, 12, 22, 24, 2, 837, DateTimeKind.Local).AddTicks(2419), false, "Đã thu" },
                    { new Guid("fc7d6e28-fc45-404f-a0ee-bd5723027f10"), "UnPay", new DateTime(2024, 10, 12, 22, 24, 2, 837, DateTimeKind.Local).AddTicks(2418), false, "Chờ thu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdmissionStatus",
                keyColumn: "Id",
                keyValue: new Guid("18b9ad46-c521-425a-a7b7-7c31ce516e31"));

            migrationBuilder.DeleteData(
                table: "AdmissionStatus",
                keyColumn: "Id",
                keyValue: new Guid("2aa31e70-f7ce-4fa9-b6dc-247666f68852"));

            migrationBuilder.DeleteData(
                table: "AdmissionStatus",
                keyColumn: "Id",
                keyValue: new Guid("c89e94d0-24cd-4af9-8854-80d9c915d0e6"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("67fb44f9-dcd9-4f2b-a14c-ce0134772bb4"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("e973b196-96b3-4bae-97e0-73296ff51cbe"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("ff65847a-2482-44cf-95e2-082be86112e4"));

            migrationBuilder.DeleteData(
                table: "InvoicesStatus",
                keyColumn: "Id",
                keyValue: new Guid("86a2ec09-7f74-49cf-a75b-1e201cbe355c"));

            migrationBuilder.DeleteData(
                table: "InvoicesStatus",
                keyColumn: "Id",
                keyValue: new Guid("cd142dd1-0c0d-4462-a7d4-2bb88f105d19"));

            migrationBuilder.DeleteData(
                table: "InvoicesStatus",
                keyColumn: "Id",
                keyValue: new Guid("fc7d6e28-fc45-404f-a0ee-bd5723027f10"));

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Specialities");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Promote");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "InvoicesStatus");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "InvoicesLine");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "AdmissionStatus");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "AdmissionLines");

            migrationBuilder.InsertData(
                table: "AdmissionStatus",
                columns: new[] { "Id", "Code", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("053ef800-fddc-401f-8fda-5549b1f628a2"), "Completed", false, "Hoàn thành" },
                    { new Guid("17ffc959-73cd-48f1-9802-3a13ac12c83d"), "Admitted", false, "Đã đăng ký" },
                    { new Guid("97cab86f-0db6-4601-9872-09d466c6b8ec"), "Canclled", false, "Đã hủy" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("180056f3-f5b1-466c-9ab2-7db2d3001024"), "Other", false, "Other" },
                    { new Guid("38db89a9-55fe-42ee-8cea-545de121c048"), "Male", false, "Male" },
                    { new Guid("d1e8b66c-b1c9-4b59-a31a-b230e1c95baf"), "FeMale", false, "FeMale" }
                });

            migrationBuilder.InsertData(
                table: "InvoicesStatus",
                columns: new[] { "Id", "Code", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("0bc1933f-e857-424d-9fae-e9ee85d5678f"), "UnPay", false, "Chờ thu" },
                    { new Guid("2b0b1539-f814-4853-b1d2-76080af13b34"), "Canclled", false, "Đã hủy" },
                    { new Guid("93d2c4b6-1977-4808-98c3-83f732f60eaf"), "Paid", false, "Đã thu" }
                });
        }
    }
}
