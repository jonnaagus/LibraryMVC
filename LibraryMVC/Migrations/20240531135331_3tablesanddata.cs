using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryMVC.Migrations
{
    /// <inheritdoc />
    public partial class _3tablesanddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookItems",
                columns: table => new
                {
                    BookItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Writer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookItems", x => x.BookItemId);
                });

            migrationBuilder.CreateTable(
                name: "LibraryMembers",
                columns: table => new
                {
                    LibraryMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryMembers", x => x.LibraryMemberId);
                });

            migrationBuilder.CreateTable(
                name: "LoanRecords",
                columns: table => new
                {
                    LoanRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    BookItemId = table.Column<int>(type: "int", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LibraryMemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRecords", x => x.LoanRecordId);
                    table.ForeignKey(
                        name: "FK_LoanRecords_BookItems_BookItemId",
                        column: x => x.BookItemId,
                        principalTable: "BookItems",
                        principalColumn: "BookItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanRecords_LibraryMembers_LibraryMemberId",
                        column: x => x.LibraryMemberId,
                        principalTable: "LibraryMembers",
                        principalColumn: "LibraryMemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookItems",
                columns: new[] { "BookItemId", "Available", "PublicationDate", "Title", "Writer" },
                values: new object[,]
                {
                    { 1, true, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter och de vises sten", "J.K. Rowling" },
                    { 2, true, new DateTime(1866, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brott och straff", "Fjodor Dostojevskij" },
                    { 3, true, new DateTime(1973, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bröderna Lejonhjärta", "Astrid Lindgren" },
                    { 4, true, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hundraåringen som klev ut genom fönstret och försvann", "Jonas Jonasson" }
                });

            migrationBuilder.InsertData(
                table: "LibraryMembers",
                columns: new[] { "LibraryMemberId", "EmailAddress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "jonna@hotmail.com", "Jonna", "Gustafsson", "0722011717" },
                    { 2, "wille@hotmail.com", "Wille", "Hellström", "0727143468" },
                    { 3, "lizzie@hotmail.com", "Lizzie", "Söderberg", "0730587700" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanRecords_BookItemId",
                table: "LoanRecords",
                column: "BookItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRecords_LibraryMemberId",
                table: "LoanRecords",
                column: "LibraryMemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanRecords");

            migrationBuilder.DropTable(
                name: "BookItems");

            migrationBuilder.DropTable(
                name: "LibraryMembers");
        }
    }
}
