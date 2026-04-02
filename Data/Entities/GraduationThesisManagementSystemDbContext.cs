using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Thesis_Management_System_BE.Data.Entities;

public partial class GraduationThesisManagementSystemDbContext : DbContext
{
    public GraduationThesisManagementSystemDbContext()
    {
    }

    public GraduationThesisManagementSystemDbContext(DbContextOptions<GraduationThesisManagementSystemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<CommitteeMember> CommitteeMembers { get; set; }

    public virtual DbSet<DefenseCommittee> DefenseCommittees { get; set; }

    public virtual DbSet<DefenseSession> DefenseSessions { get; set; }

    public virtual DbSet<Lecturer> Lecturers { get; set; }

    public virtual DbSet<LecturerAssignment> LecturerAssignments { get; set; }

    public virtual DbSet<OutlinePlan> OutlinePlans { get; set; }

    public virtual DbSet<ProgressReport> ProgressReports { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Thesis> Theses { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=THUAN-PHAM\\SQL2022;Database=Graduation_Thesis_Management_System_DB;User ID=sa;Password=thuan23082004;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4E870101E99");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.UserId, "UQ__Admin__1788CCAD762DD6AC").IsUnique();

            entity.Property(e => e.AdminId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("AdminID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.UserId)
                .HasConstraintName("FK__Admin__UserID__40C49C62");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927A0DBFC561C");

            entity.ToTable("Class");

            entity.Property(e => e.ClassId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ClassID");
            entity.Property(e => e.AcademicYear).HasMaxLength(20);
            entity.Property(e => e.ClassName).HasMaxLength(100);
            entity.Property(e => e.Cohort).HasMaxLength(100);
            entity.Property(e => e.LecturerId).HasColumnName("LecturerID");
            entity.Property(e => e.Note).HasMaxLength(255);

            entity.HasOne(d => d.Lecturer).WithMany(p => p.Classes)
                .HasForeignKey(d => d.LecturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Class__LecturerI__4959E263");
        });

        modelBuilder.Entity<CommitteeMember>(entity =>
        {
            entity.HasKey(e => new { e.CommitteeId, e.LecturerId }).HasName("PK__Committe__EF74CAB0EB95250F");

            entity.ToTable("CommitteeMember");

            entity.Property(e => e.CommitteeId).HasColumnName("CommitteeID");
            entity.Property(e => e.LecturerId).HasColumnName("LecturerID");
            entity.Property(e => e.Role).HasMaxLength(20);

            entity.HasOne(d => d.Committee).WithMany(p => p.CommitteeMembers)
                .HasForeignKey(d => d.CommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Committee__Commi__038683F8");

            entity.HasOne(d => d.Lecturer).WithMany(p => p.CommitteeMembers)
                .HasForeignKey(d => d.LecturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Committee__Lectu__047AA831");
        });

        modelBuilder.Entity<DefenseCommittee>(entity =>
        {
            entity.HasKey(e => e.CommitteeId).HasName("PK__DefenseC__2AD34121B09BDACA");

            entity.ToTable("DefenseCommittee");

            entity.Property(e => e.CommitteeId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CommitteeID");
            entity.Property(e => e.CommitteeName).HasMaxLength(100);
            entity.Property(e => e.EstablishmentDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(255);
        });

        modelBuilder.Entity<DefenseSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__DefenseS__C9F49270C6D657D5");

            entity.ToTable("DefenseSession");

            entity.Property(e => e.SessionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("SessionID");
            entity.Property(e => e.AcademicYear).HasMaxLength(100);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.Semester).HasMaxLength(20);
            entity.Property(e => e.SessionName).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Lecturer>(entity =>
        {
            entity.HasKey(e => e.LecturerId).HasName("PK__Lecturer__5A78B91DF5D29F46");

            entity.ToTable("Lecturer");

            entity.HasIndex(e => e.UserId, "UQ__Lecturer__1788CCADD746F4E9").IsUnique();

            entity.Property(e => e.LecturerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("LecturerID");
            entity.Property(e => e.AcademicDegree).HasMaxLength(100);
            entity.Property(e => e.Position).HasMaxLength(30);
            entity.Property(e => e.Specialization).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Lecturer)
                .HasForeignKey<Lecturer>(d => d.UserId)
                .HasConstraintName("FK__Lecturer__UserID__4589517F");
        });

        modelBuilder.Entity<LecturerAssignment>(entity =>
        {
            entity.HasKey(e => new { e.TopicId, e.LecturerId, e.Role }).HasName("PK__Lecturer__F95391AD59CEF72A");

            entity.ToTable("LecturerAssignment");

            entity.Property(e => e.TopicId).HasColumnName("TopicID");
            entity.Property(e => e.LecturerId).HasColumnName("LecturerID");
            entity.Property(e => e.Role).HasMaxLength(20);

            entity.HasOne(d => d.Lecturer).WithMany(p => p.LecturerAssignments)
                .HasForeignKey(d => d.LecturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LecturerA__Lectu__61316BF4");

            entity.HasOne(d => d.Topic).WithMany(p => p.LecturerAssignments)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LecturerA__Topic__603D47BB");
        });

        modelBuilder.Entity<OutlinePlan>(entity =>
        {
            entity.HasKey(e => e.OutlineId).HasName("PK__OutlineP__7A30FCE8D9BF25B3");

            entity.ToTable("OutlinePlan");

            entity.Property(e => e.OutlineId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OutlineID");
            entity.Property(e => e.ExecutionPlan).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.OutlineContent).HasMaxLength(255);
            entity.Property(e => e.SubmissionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TopicId).HasColumnName("TopicID");

            entity.HasOne(d => d.Topic).WithMany(p => p.OutlinePlans)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutlinePl__Topic__65F62111");
        });

        modelBuilder.Entity<ProgressReport>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Progress__D5BD48E5C47B18EB");

            entity.ToTable("ProgressReport");

            entity.Property(e => e.ReportId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ReportID");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.FilePath).HasMaxLength(255);
            entity.Property(e => e.ReportContent).HasMaxLength(255);
            entity.Property(e => e.TopicId).HasColumnName("TopicID");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Topic).WithMany(p => p.ProgressReports)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProgressR__Topic__6ABAD62E");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Result__9769022804A87C8E");

            entity.ToTable("Result", tb => tb.HasTrigger("trg_UpdateThesisDefenseStatus"));

            entity.HasIndex(e => e.TopicId, "UQ__Result__022E0F7CBA6F8C1A").IsUnique();

            entity.Property(e => e.ResultId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ResultID");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.DefenseScore).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.EvaluationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProcessScore).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.TopicId).HasColumnName("TopicID");

            entity.HasOne(d => d.Topic).WithOne(p => p.Result)
                .HasForeignKey<Result>(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Result__TopicID__7CD98669");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A7912ED2582");

            entity.ToTable("Student");

            entity.HasIndex(e => e.UserId, "UQ__Student__1788CCAD7034B53F").IsUnique();

            entity.Property(e => e.StudentId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("StudentID");
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__ClassID__5006DFF2");

            entity.HasOne(d => d.User).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.UserId)
                .HasConstraintName("FK__Student__UserID__4F12BBB9");
        });

        modelBuilder.Entity<Thesis>(entity =>
        {
            entity.HasKey(e => e.ThesisId).HasName("PK__Thesis__C2689BC8295EB3C7");

            entity.ToTable("Thesis");

            entity.HasIndex(e => e.TopicId, "UQ__Thesis__022E0F7CEC99B522").IsUnique();

            entity.Property(e => e.ThesisId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ThesisID");
            entity.Property(e => e.ApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Chờ duyệt");
            entity.Property(e => e.DefenseConfirmation)
                .HasMaxLength(30)
                .HasDefaultValue("Chờ duyệt");
            entity.Property(e => e.DefenseStatus)
                .HasMaxLength(30)
                .HasDefaultValue("Đang bảo vệ");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.FilePath).HasMaxLength(255);
            entity.Property(e => e.SubmissionDate).HasColumnType("datetime");
            entity.Property(e => e.TopicId).HasColumnName("TopicID");

            entity.HasOne(d => d.Topic).WithOne(p => p.Thesis)
                .HasForeignKey<Thesis>(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Thesis__TopicID__753864A1");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__Topic__022E0F7D4009B10A");

            entity.ToTable("Topic");

            entity.Property(e => e.TopicId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("TopicID");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Chờ duyệt");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.TopicTitle).HasMaxLength(200);

            entity.HasOne(d => d.Session).WithMany(p => p.Topics)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__Topic__SessionID__5C6CB6D7");

            entity.HasOne(d => d.Student).WithMany(p => p.Topics)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Topic__StudentID__5B78929E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC990C9C86");

            entity.ToTable("User");

            entity.HasIndex(e => e.IdentityNumber, "UQ__User__6354A73FCACD399D").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__User__85FB4E38076759C0").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D1053442BCFE17").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__User__C9F28456D60964A2").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Hometown).HasMaxLength(255);
            entity.Property(e => e.IdentityNumber)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
