using Assignment02.Models;
using Microsoft.EntityFrameworkCore;
// using EntityFrameworkCore.Models;

namespace Assignment02.Data
{
    public class ProductStoreContext : DbContext
    {
        public ProductStoreContext(DbContextOptions<ProductStoreContext> options) : base(options)
        {

        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureTables(modelBuilder);
            ConfigureRelationships(modelBuilder);
            SeedingData(modelBuilder);
        }

        private static void ConfigureTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                            .ToTable("Category")
                            .HasKey(cat => cat.Id);

            modelBuilder.Entity<Category>()
                            .Property(cat => cat.Id)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int")
                            .IsRequired();

            modelBuilder.Entity<Category>()
                            .Property(cat => cat.CategoryName)
                            .HasColumnName("CategoryName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500);

            modelBuilder.Entity<Product>()
                            .ToTable("Product")
                            .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                            .Property(pro => pro.Id)
                            .HasColumnName("ProductId")
                            .HasColumnType("int")
                            .IsRequired();

            modelBuilder.Entity<Product>()
                            .Property(pro => pro.ProductName)
                            .HasColumnName("ProductName")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500);

            modelBuilder.Entity<Product>()
                            .Property(pro => pro.Manufacture)
                            .HasColumnName("Manufacture")
                            .HasColumnType("nvarchar")
                            .HasMaxLength(500);

            modelBuilder.Entity<Product>()
                            .Property(pro => pro.CategoryId)
                            .HasColumnName("CategoryId")
                            .HasColumnType("int");
        }

        private static void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                            .HasOne<Category>(s => s.Category)
                            .WithMany(g => g.Products)
                            .HasForeignKey(s => s.CategoryId);
        }

        private static void SeedingData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                            .HasData(
                                new Category { Id = 1, CategoryName = "Fruit" },
                                new Category { Id = 2, CategoryName = "Animal" }
                            );

            modelBuilder.Entity<Product>()
                            .HasData(
                                new Product { Id = 1, ProductName = "Banana", Manufacture = "VN", CategoryId = 1 },
                                new Product { Id = 2, ProductName = "Cat", Manufacture = "VN", CategoryId = 2 },
                                new Product { Id = 3, ProductName = "Orange", Manufacture = "US", CategoryId = 1 },
                                new Product { Id = 4, ProductName = "Lemon", Manufacture = "JP", CategoryId = 1 },
                                new Product { Id = 5, ProductName = "Dog", Manufacture = "CN", CategoryId = 2 }
                            );
        }
    }
}