using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearnifyAPI.Models;

public partial class LearnifyContext : DbContext
{
    public LearnifyContext()
    {
    }

    public LearnifyContext(DbContextOptions<LearnifyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BCS-DASIKARAN-S; Database=Learnify; Trusted_Connection=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK_Course");

            entity.Property(e => e.CourseId).ValueGeneratedNever();
            entity.Property(e => e.CourseDescription).HasColumnType("text");
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CoursePrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CourseUser).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CourseUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseInstructor");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.Property(e => e.EnrollmentId).ValueGeneratedNever();
            entity.Property(e => e.EnrollmentDate).HasColumnType("date");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.EnrollmentCourse).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.EnrollmentCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnrollmentCourse");

            entity.HasOne(d => d.EnrollmentStudent).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.EnrollmentStudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnrollmentStudent");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.PaymentId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PayerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.PaymentEnrollment).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentEnrollmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentEnrollment");
        });

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.ToTable("Progress");

            entity.Property(e => e.ProgressId).ValueGeneratedNever();
            entity.Property(e => e.CompletionStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("date");

            entity.HasOne(d => d.ProgressCourse).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.ProgressCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProgressCourse");

            entity.HasOne(d => d.ProgressEnrollment).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.ProgressEnrollmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProgressEnrollment");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534AAC284D7").IsUnique();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.AccountType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
