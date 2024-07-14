using AcademicRecordsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademicRecordsApp.Data
{
    public partial class AcademicRecordsDBContext : DbContext
    {
        public AcademicRecordsDBContext()
        {
        }

        public AcademicRecordsDBContext(DbContextOptions<AcademicRecordsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=AcademicRecordsDB; Integrated Security=True;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.Value).HasColumnType("decimal(3, 2)");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Exams");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Students");
            });


            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Name)
                .HasMaxLength(100);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.FullName).HasMaxLength(100);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.StudentId,
                    e.CourseId
                });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
