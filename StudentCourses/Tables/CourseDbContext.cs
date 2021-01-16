using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StudentCourses.Tables
{
    public partial class CourseDbContext : DbContext
    {
        public CourseDbContext()
        {
        }

        public CourseDbContext(DbContextOptions<CourseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null) throw new ArgumentNullException(nameof(optionsBuilder));
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                    .UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Resources\\CourseDb.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null) throw new ArgumentNullException(nameof(modelBuilder));
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.CourseId)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("courseId");

                entity.Property(e => e.CourseLongName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("courseLongName");

                entity.Property(e => e.CourseShortName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("courseShortName");

                entity.Property(e => e.Credit).HasColumnName("credit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
