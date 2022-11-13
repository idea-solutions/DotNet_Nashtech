using Microsoft.EntityFrameworkCore;

using LibraryManagement.Data.Entities;
using Common.Enums;

namespace LibraryManagement.Data
{
    public class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureTables(builder);
            ConfigureRelationships(builder);
            SeedingData(builder);
        }

        private static void ConfigureTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                            .ToTable("User");

            modelBuilder.Entity<Category>()
                            .ToTable("Categories");

            modelBuilder.Entity<Book>()
                            .ToTable("Book");

            modelBuilder.Entity<BookBorrowingRequest>()
                            .ToTable("BookBorrowingRequest");
        }

        private static void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                            .HasMany(b => b.Categories)
                            .WithMany(c => c.Books)
                            .UsingEntity(b => b.ToTable("BookCategory"));

            modelBuilder.Entity<Book>()
                            .HasMany(b => b.BookBorrowingRequest)
                            .WithMany(bc => bc.Books)
                            .UsingEntity(b => b.ToTable("BookBorrowingRequestDetails"));

            modelBuilder.Entity<User>()
                            .HasMany(u => u.BookBorrowingRequests)
                            .WithOne(br => br.RequestedBy)
                            .HasForeignKey(br => br.RequestedByUserId);

            modelBuilder.Entity<User>()
                            .HasMany(u => u.ProcessedRequests)
                            .WithOne(br => br.StatusUpdateBy)
                            .HasForeignKey(br => br.StatusUpdateByUserId);
        }

        private static void SeedingData(ModelBuilder modelBuilder)
        {
            var dataCategory = new List<Category>
            {
                new Category{Id = 1, Name="Fantasy"},
                new Category{Id = 2, Name="Sci-Fi"},
                new Category{Id = 3, Name="Biography"},
                new Category{Id = 4, Name="Self-Help"},
                new Category{Id = 5, Name="Technology"},
            };

            var dataBook = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Name = "Eloquent JavaScript, Third Edition",
                    Author = "Marijn Haverbeke",
                    Summary = "JavaScript lies at the heart of almost every modern web application, from social apps like Twitter to browser-based game frameworks like Phaser and Babylon. Though simple for beginners to pick up and play with, JavaScript is a flexible, complex language that you can use to build full-scale applications.",
                },
                new Book
                {
                    Id = 2,
                    Name = "Practical Modern JavaScript",
                    Author = "Nicolas Bevacqua",
                    Summary = "To get the most out of modern JavaScript, you need learn the latest features of its parent specification, ECMAScript 6 (ES6). This book provides a highly practical look at ES6, without getting lost in the specification or its implementation details.",
                },
                new Book
                {
                    Id = 3,
                    Name = "Rethinking Productivity in Software Engineering",
                    Author = "Caitlin Sadowski",
                    Summary = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.",
                },
                new Book
                {
                    Id = 4,
                    Name = "Harry Potter and the Philosopher's Stone",
                    Author = "J. K. Rowling",
                    Summary = "Get the most out of this foundational reference and improve the productivity of your software teams. This open access book collects the wisdom of the 2017 \"Dagstuhl\" seminar on productivity in software engineering, a meeting of community leaders, who came together with the goal of rethinking traditional definitions and measures of productivity.",
                }
            };

            var dataUser = new List<User>
            {
                new User{Id = 1, Username = "hoan1", Password = "hoan1", Role = RolesEnum.SuperUser},
                new User{Id = 2, Username = "hoan2", Password = "hoan2", Role = RolesEnum.NormalUser},
                new User{Id = 3, Username = "hoan3", Password = "hoan3", Role = RolesEnum.NormalUser},
            };

            var dataBookBorrowingRequest = new List<BookBorrowingRequest>
            {
                new BookBorrowingRequest
                {
                    Id = 1,
                    Status=RequestStatusEnum.Waiting,
                    RequestedByUserId = 2,
                    DateRequested = DateTime.Now
                },
                new BookBorrowingRequest
                {
                    Id = 2,
                    Status=RequestStatusEnum.Approved,
                    RequestedByUserId = 2,
                    DateRequested = DateTime.Now,
                    StatusUpdateByUserId = 1
                }
            };

            modelBuilder.Entity<User>()
                            .HasData(dataUser);

            modelBuilder.Entity<Category>()
                            .HasData(dataCategory);

            modelBuilder.Entity<Book>()
                            .HasData(dataBook);

            modelBuilder.Entity<BookBorrowingRequest>()
                            .HasData(dataBookBorrowingRequest);

            modelBuilder.Entity<Book>()
                        .HasMany(b => b.BookBorrowingRequest)
                        .WithMany(c => c.Books)
                        .UsingEntity(b => b.HasData(
                            new { BookBorrowingRequestId = 1, BooksId = 1 },
                            new { BookBorrowingRequestId = 1, BooksId = 2 }
                        ));

            modelBuilder.Entity<Book>()
                        .HasMany(b => b.Categories)
                        .WithMany(c => c.Books)
                        .UsingEntity(b => b.HasData(
                            new { BooksId = 1, CategoriesId = 1 },
                            new { BooksId = 2, CategoriesId = 2 },
                            new { BooksId = 3, CategoriesId = 3 },
                            new { BooksId = 4, CategoriesId = 4 },
                            new { BooksId = 4, CategoriesId = 1 },
                            new { BooksId = 3, CategoriesId = 2 },
                            new { BooksId = 2, CategoriesId = 3 },
                            new { BooksId = 1, CategoriesId = 4 }
                        ));
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
