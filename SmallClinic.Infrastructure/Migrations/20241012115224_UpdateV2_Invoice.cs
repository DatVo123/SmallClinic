using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmallClinic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateV2_Invoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Specialities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AdmissionStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "AdmissionLines",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AdmissionLines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvoicesStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicesStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promote",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promote", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrommoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AdmissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Admissions_AdmissionId",
                        column: x => x.AdmissionId,
                        principalTable: "Admissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoicesStatus_InvoiceStatusId",
                        column: x => x.InvoiceStatusId,
                        principalTable: "InvoicesStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Promote_PrommoteId",
                        column: x => x.PrommoteId,
                        principalTable: "Promote",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoicesLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicesLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoicesLine_InvoicesStatus_InvoiceStatusId",
                        column: x => x.InvoiceStatusId,
                        principalTable: "InvoicesStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoicesLine_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoicesLine_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_AdmissionId",
                table: "Invoices",
                column: "AdmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceStatusId",
                table: "Invoices",
                column: "InvoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PatientId",
                table: "Invoices",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PrommoteId",
                table: "Invoices",
                column: "PrommoteId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesLine_InvoiceId",
                table: "InvoicesLine",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesLine_InvoiceStatusId",
                table: "InvoicesLine",
                column: "InvoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesLine_ServiceId",
                table: "InvoicesLine",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoicesLine");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "InvoicesStatus");

            migrationBuilder.DropTable(
                name: "Promote");

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

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Specialities");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "AdmissionStatus");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AdmissionLines");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "AdmissionLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "GenderId", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("4ba20b13-e619-4137-816b-96e8950b5e4b"), "Other", false, "Other" },
                    { new Guid("67ec75fb-cfb4-422f-a19f-8d313941387c"), "FeMale", false, "FeMale" },
                    { new Guid("91cff332-0739-434a-9e63-3f911b25d24d"), "Male", false, "Male" }
                });
        }
    }
}
