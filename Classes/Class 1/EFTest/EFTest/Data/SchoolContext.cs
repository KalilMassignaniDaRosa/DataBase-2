using EFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        // Tabela Students com permissao de leitura e escrita
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Escolher o nome da tabela
            // Se nao seria Students
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Course>().ToTable("Course");

            // Chave composta
            modelBuilder.Entity<StudentCourses>()
                .HasKey(sc => new { sc.StudentID, sc.CourseID });

            // Fk para Student
            modelBuilder.Entity<StudentCourses>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentID);

            // Fk para Course
            modelBuilder.Entity<StudentCourses>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseID);
        }
    }
}
