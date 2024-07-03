using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using SoftUni.Data;

namespace P01_StudentSystem.Data
{
    public partial class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions<SoftUniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<Homework> Homeworks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>();
            modelBuilder.Entity<Course>();
            modelBuilder.Entity<Resource>();
            modelBuilder.Entity<Homework>();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
