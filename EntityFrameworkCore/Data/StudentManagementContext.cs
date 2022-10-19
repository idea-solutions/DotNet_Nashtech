using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.Models;

namespace EntityFrameworkCore.Data
{
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options) : base(options)
        {

        }
        public DbSet<Student>? Students { get; set; }
    }
}