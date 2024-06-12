using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryMVC.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "LibraryMembers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "LibraryMembers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "LibraryMembers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "LibraryMembers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 6, 5, 23, 30, 5, 874, DateTimeKind.Local).AddTicks(1052), new DateTime(2024, 7, 20, 23, 30, 5, 874, DateTimeKind.Local).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 5, 29, 23, 30, 5, 874, DateTimeKind.Local).AddTicks(1105), new DateTime(2024, 7, 20, 23, 30, 5, 874, DateTimeKind.Local).AddTicks(1107) });

            migrationBuilder.UpdateData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 5, 31, 23, 30, 5, 874, DateTimeKind.Local).AddTicks(1108), new DateTime(2024, 7, 20, 23, 30, 5, 874, DateTimeKind.Local).AddTicks(1110) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "LibraryMembers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "LibraryMembers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "LibraryMembers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "LibraryMembers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 1,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 5, 30, 11, 53, 51, 929, DateTimeKind.Local).AddTicks(2006), null });

            migrationBuilder.UpdateData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 2,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 5, 23, 11, 53, 51, 929, DateTimeKind.Local).AddTicks(2083), null });

            migrationBuilder.UpdateData(
                table: "LoanRecords",
                keyColumn: "LoanRecordId",
                keyValue: 3,
                columns: new[] { "BorrowDate", "ReturnDate" },
                values: new object[] { new DateTime(2024, 5, 25, 11, 53, 51, 929, DateTimeKind.Local).AddTicks(2085), null });
        }
    }
}
