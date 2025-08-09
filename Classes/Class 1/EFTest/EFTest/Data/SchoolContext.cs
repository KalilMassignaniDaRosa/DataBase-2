using EFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Escolher o nome da tabela
            // Se nao seria Students
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
