using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmallClinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBfinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Code",
                table: "InvoicesLine");

            migrationBuilder.DropColumn(
                name: "AdmissionAmount",
                table: "Admissions");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "InvoicesLine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "AdmissionLines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AdmissionStatus",
                columns: new[] { "Id", "Code", "CreateDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("99738e6c-1c1b-4886-91a3-a6871db509a3"), "Canclled", new DateTime(2024, 10, 13, 23, 22, 58, 358, DateTimeKind.Local).AddTicks(3748), false, "Đã hủy" },
                    { new Guid("a5b4151e-09a9-4d06-8b53-9852f1105067"), "Completed", new DateTime(2024, 10, 13, 23, 22, 58, 358, DateTimeKind.Local).AddTicks(3725), false, "Hoàn thành" },
                    { new Guid("c2c6afd8-ef89-426b-9ac9-fb9a8e0da881"), "Admitted", new DateTime(2024, 10, 13, 23, 22, 58, 358, DateTimeKind.Local).AddTicks(3714), false, "Đã đăng ký" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "CreateDate", "GenderId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("4a307cc2-6600-4235-bb24-bd1eb92b4d54"), new DateTime(2024, 10, 13, 23, 22, 58, 358, DateTimeKind.Local).AddTicks(4229), "Male", false, "Male" },
                    { new Guid("4edebd34-e84b-4876-9799-4e2976aba9c1"), new DateTime(2024, 10, 13, 23, 22, 58, 358, DateTimeKind.Local).AddTicks(4232), "FeMale", false, "FeMale" },
                    { new Guid("cc966a91-8c80-41f3-8192-26d0dbfda021"), new DateTime(2024, 10, 13, 23, 22, 58, 358, DateTimeKind.Local).AddTicks(4234), "Other", false, "Other" }
                });

            migrationBuilder.InsertData(
                table: "InvoicesStatus",
                columns: new[] { "Id", "Code", "CreateDate", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("490fc390-0947-455c-abbc-044de806c215"), "UnPay", new DateTime(2024, 10, 13, 23, 22, 58, 358, DateTimeKind.Local).AddTicks(4194), false, "Chờ thu" },
                    { new Guid("ed42da9c-2c0f-4248-b42f-0f78a885593e"), "Canclled", new DateTime(2024, 10, 13, 23, 22, 58, 358, DateTimeKind.Local).AddTicks(4197), false, "Đã hủy" },
                    { new Guid("ff48794c-1bb5-4141-96df-f12564fdc8f0"), "Paid", new DateTime(2024, 10, 13, 23, 22, 58, 358, DateTimeKind.Local).AddTicks(4196), false, "Đã thu" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdmissionStatus",
                keyColumn: "Id",
                keyValue: new Guid("99738e6c-1c1b-4886-91a3-a6871db509a3"));

            migrationBuilder.DeleteData(
                table: "AdmissionStatus",
                keyColumn: "Id",
                keyValue: new Guid("a5b4151e-09a9-4d06-8b53-9852f1105067"));

            migrationBuilder.DeleteData(
                table: "AdmissionStatus",
                keyColumn: "Id",
                keyValue: new Guid("c2c6afd8-ef89-426b-9ac9-fb9a8e0da881"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a307cc2-6600-4235-bb24-bd1eb92b4d54"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4edebd34-e84b-4876-9799-4e2976aba9c1"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("cc966a91-8c80-41f3-8192-26d0dbfda021"));

            migrationBuilder.DeleteData(
                table: "InvoicesStatus",
                keyColumn: "Id",
                keyValue: new Guid("490fc390-0947-455c-abbc-044de806c215"));

            migrationBuilder.DeleteData(
                table: "InvoicesStatus",
                keyColumn: "Id",
                keyValue: new Guid("ed42da9c-2c0f-4248-b42f-0f78a885593e"));

            migrationBuilder.DeleteData(
                table: "InvoicesStatus",
                keyColumn: "Id",
                keyValue: new Guid("ff48794c-1bb5-4141-96df-f12564fdc8f0"));

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "InvoicesLine");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "AdmissionLines");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "InvoicesLine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "AdmissionAmount",
                table: "Admissions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
    }
}
