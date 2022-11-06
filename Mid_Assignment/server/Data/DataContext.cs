using Microsoft.EntityFrameworkCore;

using Data.Entities;
using Common.Enums;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
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
            // User
            modelBuilder.Entity<User>()
                            .ToTable("User");
            // Category
            modelBuilder.Entity<Category>()
                            .ToTable("Categories");

            // Book
            modelBuilder.Entity<Book>()
                            .ToTable("Book");

            // BookBorrowingRequest
            modelBuilder.Entity<BookBorrowingRequest>()
                            .ToTable("BookBorrowingRequest");

            // BookBorrowingRequestDetails
            modelBuilder.Entity<BookBorrowingRequestDetails>()
                            .ToTable("BookBorrowingRequestDetails")
                            .HasKey(rb => new { rb.BookBorrowingRequestId, rb.BookId });

            modelBuilder.Entity<BookCategory>()
                            .ToTable("BookCategory")
                            .HasKey(t => new { t.BookId, t.CategoryId });
        }

        private static void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // Book
            modelBuilder.Entity<BookCategory>()
                            .HasOne(p => p.Book)
                            .WithMany(pt => pt.BookCategories)
                            .HasForeignKey(pt => pt.BookId);

            // Category
            modelBuilder.Entity<BookCategory>()
                            .HasOne(pt => pt.Category)
                            .WithMany(p => p.BookCategories)
                            .HasForeignKey(pt => pt.CategoryId)
                            .IsRequired();

            // BookBorrowingRequestDetails
            modelBuilder.Entity<BookBorrowingRequestDetails>()
                            .HasOne<BookBorrowingRequest>(rb => rb.BookBorrowingRequest)
                            .WithMany(s => s.RequestDetails)
                            .HasForeignKey(rb => rb.BookBorrowingRequestId)
                            .IsRequired();

            modelBuilder.Entity<BookBorrowingRequestDetails>()
                            .HasOne<Book>(rb => rb.Book)
                            .WithMany(s => s.RequestDetails)
                            .HasForeignKey(rb => rb.BookId)
                            .IsRequired();

            // User
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
                new Category{Id = 5, Name="Reference"},
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

            var dataBookCategory = new List<BookCategory>
            {
                new BookCategory{Id = 1, BookId = 1, CategoryId = 1},
                new BookCategory{Id = 2, BookId = 2, CategoryId = 1},
                new BookCategory{Id = 3, BookId = 3, CategoryId = 2},
                new BookCategory{Id = 4, BookId = 4, CategoryId = 3},
                new BookCategory{Id = 5, BookId = 4, CategoryId = 2},
                new BookCategory{Id = 6, BookId = 3, CategoryId = 3},
                new BookCategory{Id = 7, BookId = 2, CategoryId = 2},
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
                    Status=RequestStatusEnum.Waiting,
                    RequestedByUserId = 3,
                    DateRequested = DateTime.Now
                },
                new BookBorrowingRequest
                {
                    Id = 3,
                    Status=RequestStatusEnum.Approved,
                    RequestedByUserId = 2,
                    DateRequested = DateTime.Now,
                    StatusUpdateByUserId = 1
                },
                new BookBorrowingRequest
                {
                    Id = 4,
                    Status=RequestStatusEnum.Rejected,
                    RequestedByUserId = 3,
                    DateRequested = DateTime.Now,
                    StatusUpdateByUserId = 1
                },
            };

            var dataBookBorrowingRequestDetails = new List<BookBorrowingRequestDetails>
            {
                new BookBorrowingRequestDetails{Id = 1, BookBorrowingRequestId = 1, BookId = 1},
                new BookBorrowingRequestDetails{Id = 2, BookBorrowingRequestId = 1, BookId = 2},
                new BookBorrowingRequestDetails{Id = 3, BookBorrowingRequestId = 1, BookId = 3},
                new BookBorrowingRequestDetails{Id = 4, BookBorrowingRequestId = 2, BookId = 4},
                new BookBorrowingRequestDetails{Id = 5, BookBorrowingRequestId = 1, BookId = 4},
                new BookBorrowingRequestDetails{Id = 6, BookBorrowingRequestId = 2, BookId = 2},
                new BookBorrowingRequestDetails{Id = 7, BookBorrowingRequestId = 3, BookId = 1},
            };

            modelBuilder.Entity<User>()
                            .HasData(dataUser);

            modelBuilder.Entity<Category>()
                            .HasData(dataCategory);

            modelBuilder.Entity<Book>()
                            .HasData(dataBook);

            modelBuilder.Entity<BookCategory>()
                            .HasData(dataBookCategory);

            modelBuilder.Entity<BookBorrowingRequest>()
                            .HasData(dataBookBorrowingRequest);

            modelBuilder.Entity<BookBorrowingRequestDetails>()
                            .HasData(dataBookBorrowingRequestDetails);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
