﻿// <auto-generated />
using System;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagement.Data.Migrations
{
    [DbContext(typeof(LibraryManagementContext))]
    [Migration("20221111102513_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookBookBorrowingRequest", b =>
                {
                    b.Property<int>("BookBorrowingRequestId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("BookBorrowingRequestId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("BookBorrowingRequestDetails", (string)null);

                    b.HasData(
                        new
                        {
                            BookBorrowingRequestId = 1,
                            BooksId = 1
                        },
                        new
                        {
                            BookBorrowingRequestId = 1,
                            BooksId = 2
                        },
                        new
                        {
                            BookBorrowingRequestId = 1,
                            BooksId = 3
                        },
                        new
                        {
                            BookBorrowingRequestId = 2,
                            BooksId = 4
                        },
                        new
                        {
                            BookBorrowingRequestId = 1,
                            BooksId = 4
                        },
                        new
                        {
                            BookBorrowingRequestId = 2,
                            BooksId = 2
                        },
                        new
                        {
                            BookBorrowingRequestId = 3,
                            BooksId = 1
                        });
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("BookCategory", (string)null);

                    b.HasData(
                        new
                        {
                            BooksId = 1,
                            CategoriesId = 1
                        },
                        new
                        {
                            BooksId = 2,
                            CategoriesId = 2
                        },
                        new
                        {
                            BooksId = 3,
                            CategoriesId = 3
                        },
                        new
                        {
                            BooksId = 4,
                            CategoriesId = 4
                        },
                        new
                        {
                            BooksId = 4,
                            CategoriesId = 1
                        },
                        new
                        {
                            BooksId = 3,
                            CategoriesId = 2
                        },
                        new
                        {
                            BooksId = 2,
                            CategoriesId = 3
                        },
                        new
                        {
                            BooksId = 1,
                            CategoriesId = 4
                        });
                });

            modelBuilder.Entity("LibraryManagement.Data.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Book", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Marijn Haverbeke",
                            Name = "Eloquent JavaScript, Third Edition",
                            Summary = "JavaScript lies at the heart of almost every modern web application, from social apps like Twitter to browser-based game frameworks like Phaser and Babylon. Though simple for beginners to pick up and play with, JavaScript is a flexible, complex language that you can use to build full-scale applications."
                        },
                        new
                        {
                            Id = 2,
                            Author = "Nicolas Bevacqua",
                            Name = "Practical Modern JavaScript",
                            Summary = "To get the most out of modern JavaScript, you need learn the latest features of its parent specification, ECMAScript 6 (ES6). This book provides a highly practical look at ES6, without getting lost in the specification or its implementation details."
                        },
                        new
                        {
                            Id = 3,
                            Author = "Caitlin Sadowski",
                            Name = "Rethinking Productivity in Software Engineering",
                            Summary = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated."
                        },
                        new
                        {
                            Id = 4,
                            Author = "J. K. Rowling",
                            Name = "Harry Potter and the Philosopher's Stone",
                            Summary = "Get the most out of this foundational reference and improve the productivity of your software teams. This open access book collects the wisdom of the 2017 \"Dagstuhl\" seminar on productivity in software engineering, a meeting of community leaders, who came together with the goal of rethinking traditional definitions and measures of productivity."
                        });
                });

            modelBuilder.Entity("LibraryManagement.Data.Entities.BookBorrowingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("StatusUpdateByUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestedByUserId");

                    b.HasIndex("StatusUpdateByUserId");

                    b.ToTable("BookBorrowingRequest", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRequested = new DateTime(2022, 11, 11, 17, 25, 13, 366, DateTimeKind.Local).AddTicks(312),
                            RequestedByUserId = 2,
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            DateRequested = new DateTime(2022, 11, 11, 17, 25, 13, 366, DateTimeKind.Local).AddTicks(322),
                            RequestedByUserId = 3,
                            Status = 0
                        },
                        new
                        {
                            Id = 3,
                            DateRequested = new DateTime(2022, 11, 11, 17, 25, 13, 366, DateTimeKind.Local).AddTicks(323),
                            RequestedByUserId = 2,
                            Status = 1,
                            StatusUpdateByUserId = 1
                        },
                        new
                        {
                            Id = 4,
                            DateRequested = new DateTime(2022, 11, 11, 17, 25, 13, 366, DateTimeKind.Local).AddTicks(324),
                            RequestedByUserId = 3,
                            Status = -1,
                            StatusUpdateByUserId = 1
                        });
                });

            modelBuilder.Entity("LibraryManagement.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Biography"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Self-Help"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Technology"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "hoan1",
                            Role = 0,
                            Username = "hoan1"
                        },
                        new
                        {
                            Id = 2,
                            Password = "hoan2",
                            Role = 1,
                            Username = "hoan2"
                        },
                        new
                        {
                            Id = 3,
                            Password = "hoan3",
                            Role = 1,
                            Username = "hoan3"
                        });
                });

            modelBuilder.Entity("BookBookBorrowingRequest", b =>
                {
                    b.HasOne("LibraryManagement.Data.Entities.BookBorrowingRequest", null)
                        .WithMany()
                        .HasForeignKey("BookBorrowingRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Data.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.HasOne("LibraryManagement.Data.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Data.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryManagement.Data.Entities.BookBorrowingRequest", b =>
                {
                    b.HasOne("LibraryManagement.Data.Entities.User", "RequestedBy")
                        .WithMany("BookBorrowingRequests")
                        .HasForeignKey("RequestedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Data.Entities.User", "StatusUpdateBy")
                        .WithMany("ProcessedRequests")
                        .HasForeignKey("StatusUpdateByUserId");

                    b.Navigation("RequestedBy");

                    b.Navigation("StatusUpdateBy");
                });

            modelBuilder.Entity("LibraryManagement.Data.Entities.User", b =>
                {
                    b.Navigation("BookBorrowingRequests");

                    b.Navigation("ProcessedRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
