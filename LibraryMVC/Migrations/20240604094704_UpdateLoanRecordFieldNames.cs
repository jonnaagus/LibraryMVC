using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLoanRecordFieldNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 1,
                column: "BorrowDate",
                value: new DateTime(2024, 5, 30, 11, 47, 3, 897, DateTimeKind.Local).AddTicks(9193));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 1,
                column: "BorrowDate",
                value: new DateTime(2024, 5, 30, 11, 46, 3, 943, DateTimeKind.Local).AddTicks(2863));
        }
    }
}
