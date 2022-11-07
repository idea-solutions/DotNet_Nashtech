using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "User",
                newName: "Password");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookBorrowingRequestId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRequested",
                value: new DateTime(2022, 11, 7, 19, 7, 58, 500, DateTimeKind.Local).AddTicks(3453));

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRequested",
                value: new DateTime(2022, 11, 7, 19, 7, 58, 500, DateTimeKind.Local).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRequested",
                value: new DateTime(2022, 11, 7, 19, 7, 58, 500, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateRequested", "Status" },
                values: new object[] { new DateTime(2022, 11, 7, 19, 7, 58, 500, DateTimeKind.Local).AddTicks(3464), -1 });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BookId",
                table: "Categories",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookBorrowingRequestId",
                table: "Book",
                column: "BookBorrowingRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookBorrowingRequest_BookBorrowingRequestId",
                table: "Book",
                column: "BookBorrowingRequestId",
                principalTable: "BookBorrowingRequest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Book_BookId",
                table: "Categories",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookBorrowingRequest_BookBorrowingRequestId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Book_BookId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_BookId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookBorrowingRequestId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BookBorrowingRequestId",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "PasswordSalt");

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRequested",
                value: new DateTime(2022, 11, 6, 17, 42, 31, 941, DateTimeKind.Local).AddTicks(9460));

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRequested",
                value: new DateTime(2022, 11, 6, 17, 42, 31, 941, DateTimeKind.Local).AddTicks(9469));

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRequested",
                value: new DateTime(2022, 11, 6, 17, 42, 31, 941, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateRequested", "Status" },
                values: new object[] { new DateTime(2022, 11, 6, 17, 42, 31, 941, DateTimeKind.Local).AddTicks(9472), 2 });
        }
    }
}
