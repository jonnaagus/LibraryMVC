using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryMVC.Migrations
{
    /// <inheritdoc />
    public partial class Add2SeedLoanRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 1,
                column: "BorrowDate",
                value: new DateTime(2024, 5, 30, 11, 53, 51, 929, DateTimeKind.Local).AddTicks(2006));

            migrationBuilder.InsertData(
                table: "LoanRecords",
                columns: new[] { "LoanRecordId", "BookItemId", "BorrowDate", "LibraryMemberId", "ReturnDate" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2024, 5, 23, 11, 53, 51, 929, DateTimeKind.Local).AddTicks(2083), 2, null },
                    { 3, 4, new DateTime(2024, 5, 25, 11, 53, 51, 929, DateTimeKind.Local).AddTicks(2085), 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 1,
                column: "BorrowDate",
                value: new DateTime(2024, 5, 30, 11, 47, 3, 897, DateTimeKind.Local).AddTicks(9193));
        }
    }
}
