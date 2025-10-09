using EFTest.Models.Courses;
using EFTest.Models.Modules;
using EFTest.Models.Students;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Data
{
    // Construtor primario
    // Declara contrutor e parametros junto com a classe
    public class SchoolContext(DbContextOptions<SchoolContext> options) : DbContext(options)
    {

        // Tabela Students com permissao de leitura e escrita
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentModule> StudentModules { get; set; }

        public DbSet<CourseModule> CourseModules { get; set; }
        public DbSet<ModulePrerequisite> ModulePrerequisites { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Escolher o nome da tabela
            // Se nao seria Students
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Module>().ToTable("Module");
            modelBuilder.Entity<StudentCourse>().ToTable("StudentCourse");
            modelBuilder.Entity<CourseModule>().ToTable("CourseModule");
            modelBuilder.Entity<ModulePrerequisite>().ToTable("ModulePrerequisite");
            modelBuilder.Entity<StudentModule>().ToTable("StudentModule");

            #region StudentCourses
            // Chave composta
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentID, sc.CourseID });

            // FK para Student
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses) 
                .HasForeignKey(sc => sc.StudentID);

            // FK para Course
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses) 
                .HasForeignKey(sc => sc.CourseID);
            #endregion

            #region CourseModule
            // Chave composta
            modelBuilder.Entity<CourseModule>()
                .HasKey(cm => new { cm.CourseID, cm.ModuleID });

            // FK para Course
            modelBuilder.Entity<CourseModule>()
                .HasOne(cm => cm.Course)
                .WithMany(c => c.CourseModules) 
                .HasForeignKey(cm => cm.CourseID);

            // FK para Module
            modelBuilder.Entity<CourseModule>()
                .HasOne(cm => cm.Module)
                .WithMany(m => m.CourseModules) 
                .HasForeignKey(cm => cm.ModuleID);
            #endregion

            #region ModulePrerequisite
            // Chave composta
            modelBuilder.Entity<ModulePrerequisite>()
                .HasKey(mp => new { mp.ModuleID, mp.PrerequisiteID });

            // FK para Module 
            modelBuilder.Entity<ModulePrerequisite>()
                .HasOne(mp => mp.Module)
                .WithMany(m => m.Prerequisites) 
                .HasForeignKey(mp => mp.ModuleID)
                // evita delete em cascata circular
                .OnDelete(DeleteBehavior.Restrict); 

            // FK para Prerequisite
            modelBuilder.Entity<ModulePrerequisite>()
                .HasOne(mp => mp.Prerequisite)
                .WithMany(m => m.IsPrerequisiteFor) 
                .HasForeignKey(mp => mp.PrerequisiteID)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region StudentModule
            // Chave composta tripla
            modelBuilder.Entity<StudentModule>()
                .HasKey(sm => new { sm.StudentID, sm.ModuleID, sm.CourseID });

            // FK para Student
            modelBuilder.Entity<StudentModule>()
                .HasOne(sm => sm.Student)
                .WithMany(s => s.StudentModules)
                .HasForeignKey(sm => sm.StudentID);

            // FK para Module
            modelBuilder.Entity<StudentModule>()
                .HasOne(sm => sm.Module)
                .WithMany(m => m.StudentModules)
                .HasForeignKey(sm => sm.ModuleID);

            // FK para Course
            modelBuilder.Entity<StudentModule>()
                .HasOne(sm => sm.Course)
                .WithMany()
                .HasForeignKey(sm => sm.CourseID);
            #endregion
        }
    }
}