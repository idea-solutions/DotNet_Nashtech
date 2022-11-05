using Microsoft.EntityFrameworkCore;

using Data.Entities;

namespace Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
