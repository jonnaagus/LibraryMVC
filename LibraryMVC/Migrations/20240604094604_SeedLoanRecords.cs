using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryMVC.Migrations
{
    /// <inheritdoc />
    public partial class SeedLoanRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookItems",
                keyColumn: "BookItemId",
                keyValue: 1,
                column: "Available",
                value: false);

            migrationBuilder.UpdateData(
                table: "BookItems",
                keyColumn: "BookItemId",
                keyValue: 2,
                column: "Available",
                value: false);

            migrationBuilder.UpdateData(
                table: "BookItems",
                keyColumn: "BookItemId",
                keyValue: 4,
                column: "Available",
                value: false);

            migrationBuilder.InsertData(
                table: "LoanRecords",
                columns: new[] { "LoanRecordId", "BookItemId", "BorrowDate", "LibraryMemberId", "ReturnDate" },
                values: new object[] { 1, 2, new DateTime(2024, 5, 30, 11, 46, 3, 943, DateTimeKind.Local).AddTicks(2863), 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "BookItems",
                keyColumn: "BookItemId",
                keyValue: 1,
                column: "Available",
                value: true);

            migrationBuilder.UpdateData(
                table: "BookItems",
                keyColumn: "BookItemId",
                keyValue: 2,
                column: "Available",
                value: true);

            migrationBuilder.UpdateData(
                table: "BookItems",
                keyColumn: "BookItemId",
                keyValue: 4,
                column: "Available",
                value: true);
        }
    }
}
