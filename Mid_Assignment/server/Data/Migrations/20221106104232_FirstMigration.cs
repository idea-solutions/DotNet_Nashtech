using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestedByUserId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusUpdateByUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequest_User_RequestedByUserId",
                        column: x => x.RequestedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequest_User_StatusUpdateByUserId",
                        column: x => x.StatusUpdateByUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowingRequestDetails",
                columns: table => new
                {
                    BookBorrowingRequestId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowingRequestDetails", x => new { x.BookBorrowingRequestId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetails_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrowingRequestDetails_BookBorrowingRequest_BookBorrowingRequestId",
                        column: x => x.BookBorrowingRequestId,
                        principalTable: "BookBorrowingRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "Name", "Summary" },
                values: new object[,]
                {
                    { 1, "Marijn Haverbeke", "Eloquent JavaScript, Third Edition", "JavaScript lies at the heart of almost every modern web application, from social apps like Twitter to browser-based game frameworks like Phaser and Babylon. Though simple for beginners to pick up and play with, JavaScript is a flexible, complex language that you can use to build full-scale applications." },
                    { 2, "Nicolas Bevacqua", "Practical Modern JavaScript", "To get the most out of modern JavaScript, you need learn the latest features of its parent specification, ECMAScript 6 (ES6). This book provides a highly practical look at ES6, without getting lost in the specification or its implementation details." },
                    { 3, "Caitlin Sadowski", "Rethinking Productivity in Software Engineering", "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated." },
                    { 4, "J. K. Rowling", "Harry Potter and the Philosopher's Stone", "Get the most out of this foundational reference and improve the productivity of your software teams. This open access book collects the wisdom of the 2017 \"Dagstuhl\" seminar on productivity in software engineering, a meeting of community leaders, who came together with the goal of rethinking traditional definitions and measures of productivity." }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Sci-Fi" },
                    { 3, "Biography" },
                    { 4, "Self-Help" },
                    { 5, "Reference" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "PasswordSalt", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "hoan1", 1, "hoan1" },
                    { 2, "hoan2", 0, "hoan2" },
                    { 3, "hoan3", 0, "hoan3" }
                });

            migrationBuilder.InsertData(
                table: "BookBorrowingRequest",
                columns: new[] { "Id", "DateRequested", "RequestedByUserId", "Status", "StatusUpdateByUserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 6, 17, 42, 31, 941, DateTimeKind.Local).AddTicks(9460), 2, 0, null },
                    { 2, new DateTime(2022, 11, 6, 17, 42, 31, 941, DateTimeKind.Local).AddTicks(9469), 3, 0, null },
                    { 3, new DateTime(2022, 11, 6, 17, 42, 31, 941, DateTimeKind.Local).AddTicks(9470), 2, 1, 1 },
                    { 4, new DateTime(2022, 11, 6, 17, 42, 31, 941, DateTimeKind.Local).AddTicks(9472), 3, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "BookId", "CategoryId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 2, 2, 7 },
                    { 3, 2, 3 },
                    { 3, 3, 6 },
                    { 4, 2, 5 },
                    { 4, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "BookBorrowingRequestDetails",
                columns: new[] { "BookBorrowingRequestId", "BookId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 2 },
                    { 1, 3, 3 },
                    { 1, 4, 5 },
                    { 2, 2, 6 },
                    { 2, 4, 4 },
                    { 3, 1, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequest_RequestedByUserId",
                table: "BookBorrowingRequest",
                column: "RequestedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequest_StatusUpdateByUserId",
                table: "BookBorrowingRequest",
                column: "StatusUpdateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowingRequestDetails_BookId",
                table: "BookBorrowingRequestDetails",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrowingRequestDetails");

            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "BookBorrowingRequest");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
