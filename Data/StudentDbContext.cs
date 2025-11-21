using Microsoft.EntityFrameworkCore;
using StudentManagement.API.Models;
using StudentManagement.API.Models;
namespace StudentManagement.API.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
