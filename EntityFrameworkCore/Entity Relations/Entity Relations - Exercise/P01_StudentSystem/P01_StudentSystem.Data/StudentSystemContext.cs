using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity
                    .Property(s => s.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);

                entity
                    .Property(s => s.PhoneNumber)
                    .IsRequired(false)
                    .IsUnicode(false)
                    .HasColumnType("char(10)");

                entity
                    .Property(s => s.Birthday)
                    .IsRequired(false);

                entity
                    .HasMany(s => s.HomeworkSubmissions)
                    .WithOne(h => h.Student)
                    .HasForeignKey(h => h.StudentId);

                entity
                    .HasMany(sc => sc.CourseEnrollments)
                    .WithOne(c => c.Student)
                    .HasForeignKey(sc => sc.StudentId);
                    
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);

                entity
                    .Property(c => c.Name)
                    .IsUnicode()
                    .HasMaxLength(80);

                entity
                    .Property(c => c.Description)
                    .IsUnicode()
                    .IsRequired(false);

                entity
                    .HasMany(c => c.HomeworkSubmissions)
                    .WithOne(h => h.Course)
                    .HasForeignKey(h => h.CourseId);

                entity
                    .HasMany(c => c.Resources)
                    .WithOne(r => r.Course)
                    .HasForeignKey(r => r.CourseId);

                entity
                    .HasMany(c => c.StudentsEnrolled)
                    .WithOne(sc => sc.Course)
                    .HasForeignKey(sc => sc.CourseId);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);

                entity
                    .Property(r => r.Name)
                    .IsUnicode()
                    .HasMaxLength(50);

                entity
                    .Property(r => r.Url)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(h => h.HomeworkId);

                entity.ToTable("HomeworkSubmissions");

                entity
                    .Property(h => h.Content)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity.ToTable("StudentCourses");
            });

            modelBuilder.Entity<ContentType>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
