using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BookBorrowingRequest",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRequested", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 11, 17, 25, 13, 366, DateTimeKind.Local).AddTicks(312), null });

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateRequested", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 11, 17, 25, 13, 366, DateTimeKind.Local).AddTicks(322), null });

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateRequested", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 11, 17, 25, 13, 366, DateTimeKind.Local).AddTicks(323), null });

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateRequested", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 11, 17, 25, 13, 366, DateTimeKind.Local).AddTicks(324), null });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Role",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdated",
                table: "BookBorrowingRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRequested", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 9, 13, 26, 18, 389, DateTimeKind.Local).AddTicks(3889), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateRequested", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 9, 13, 26, 18, 389, DateTimeKind.Local).AddTicks(3897), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateRequested", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 9, 13, 26, 18, 389, DateTimeKind.Local).AddTicks(3898), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookBorrowingRequest",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateRequested", "DateUpdated" },
                values: new object[] { new DateTime(2022, 11, 9, 13, 26, 18, 389, DateTimeKind.Local).AddTicks(3899), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: 1);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "Role",
                value: 0);
        }
    }
}
