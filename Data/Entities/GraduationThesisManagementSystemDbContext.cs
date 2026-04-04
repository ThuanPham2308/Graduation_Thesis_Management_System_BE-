using System;
using System.Collections.Generic;
using Graduation_Thesis_Management_System_BE.Models.Entities;
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
        => optionsBuilder.UseSqlServer("Data Source=THUAN-PHAM\\SQL2022;Initial Catalog=Graduation_Thesis_Management_System_DB;User ID=sa;Password=thuan23082004;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4E809E0C274");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.UserId, "UQ__Admin__1788CCADF2BA1B10").IsUnique();

            entity.Property(e => e.AdminId)
                .HasMaxLength(20)
                .HasColumnName("AdminID");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.UserId)
                .HasConstraintName("FK__Admin__UserID__0E6E26BF");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927A0FE5E71DF");

            entity.ToTable("Class");

            entity.Property(e => e.ClassId)
                .HasMaxLength(20)
                .HasColumnName("ClassID");
            entity.Property(e => e.AcademicYear).HasMaxLength(20);
            entity.Property(e => e.ClassName).HasMaxLength(100);
            entity.Property(e => e.Cohort).HasMaxLength(100);
            entity.Property(e => e.LecturerId)
                .HasMaxLength(20)
                .HasColumnName("LecturerID");
            entity.Property(e => e.Note).HasMaxLength(255);

            entity.HasOne(d => d.Lecturer).WithMany(p => p.Classes)
                .HasForeignKey(d => d.LecturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Class__LecturerI__151B244E");
        });

        modelBuilder.Entity<CommitteeMember>(entity =>
        {
            entity.HasKey(e => new { e.CommitteeId, e.LecturerId }).HasName("PK__Committe__EF74CAB0B7BBD701");

            entity.ToTable("CommitteeMember");

            entity.Property(e => e.CommitteeId)
                .HasMaxLength(20)
                .HasColumnName("CommitteeID");
            entity.Property(e => e.LecturerId)
                .HasMaxLength(20)
                .HasColumnName("LecturerID");
            entity.Property(e => e.Role).HasMaxLength(20);

            entity.HasOne(d => d.Committee).WithMany(p => p.CommitteeMembers)
                .HasForeignKey(d => d.CommitteeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Committee__Commi__47A6A41B");

            entity.HasOne(d => d.Lecturer).WithMany(p => p.CommitteeMembers)
                .HasForeignKey(d => d.LecturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Committee__Lectu__489AC854");
        });

        modelBuilder.Entity<DefenseCommittee>(entity =>
        {
            entity.HasKey(e => e.CommitteeId).HasName("PK__DefenseC__2AD34121C4B58CE4");

            entity.ToTable("DefenseCommittee");

            entity.Property(e => e.CommitteeId)
                .HasMaxLength(20)
                .HasColumnName("CommitteeID");
            entity.Property(e => e.CommitteeName).HasMaxLength(100);
            entity.Property(e => e.EstablishmentDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(255);
        });

        modelBuilder.Entity<DefenseSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__DefenseS__C9F49270DFAB7B23");

            entity.ToTable("DefenseSession");

            entity.Property(e => e.SessionId)
                .HasMaxLength(20)
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
            entity.HasKey(e => e.LecturerId).HasName("PK__Lecturer__5A78B91DA4C1FB20");

            entity.ToTable("Lecturer");

            entity.HasIndex(e => e.UserId, "UQ__Lecturer__1788CCADC1D0B66C").IsUnique();

            entity.Property(e => e.LecturerId)
                .HasMaxLength(20)
                .HasColumnName("LecturerID");
            entity.Property(e => e.AcademicDegree).HasMaxLength(100);
            entity.Property(e => e.Position).HasMaxLength(30);
            entity.Property(e => e.Specialization).HasMaxLength(100);
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Lecturer)
                .HasForeignKey<Lecturer>(d => d.UserId)
                .HasConstraintName("FK__Lecturer__UserID__123EB7A3");
        });

        modelBuilder.Entity<LecturerAssignment>(entity =>
        {
            entity.HasKey(e => new { e.TopicId, e.LecturerId, e.Role }).HasName("PK__Lecturer__F95391AD137970F3");

            entity.ToTable("LecturerAssignment");

            entity.Property(e => e.TopicId)
                .HasMaxLength(20)
                .HasColumnName("TopicID");
            entity.Property(e => e.LecturerId)
                .HasMaxLength(20)
                .HasColumnName("LecturerID");
            entity.Property(e => e.Role).HasMaxLength(20);

            entity.HasOne(d => d.Lecturer).WithMany(p => p.LecturerAssignments)
                .HasForeignKey(d => d.LecturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LecturerA__Lectu__2A164134");

            entity.HasOne(d => d.Topic).WithMany(p => p.LecturerAssignments)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LecturerA__Topic__29221CFB");
        });

        modelBuilder.Entity<OutlinePlan>(entity =>
        {
            entity.HasKey(e => e.OutlineId).HasName("PK__OutlineP__7A30FCE8EDDC0336");

            entity.ToTable("OutlinePlan");

            entity.Property(e => e.OutlineId)
                .HasMaxLength(20)
                .HasColumnName("OutlineID");
            entity.Property(e => e.ExecutionPlan).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.OutlineContent).HasMaxLength(255);
            entity.Property(e => e.SubmissionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TopicId)
                .HasMaxLength(20)
                .HasColumnName("TopicID");

            entity.HasOne(d => d.Topic).WithMany(p => p.OutlinePlans)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OutlinePl__Topic__2DE6D218");
        });

        modelBuilder.Entity<ProgressReport>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Progress__D5BD48E531E54D0F");

            entity.ToTable("ProgressReport");

            entity.Property(e => e.ReportId)
                .HasMaxLength(20)
                .HasColumnName("ReportID");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.FilePath).HasMaxLength(255);
            entity.Property(e => e.ReportContent).HasMaxLength(255);
            entity.Property(e => e.TopicId)
                .HasMaxLength(20)
                .HasColumnName("TopicID");
            entity.Property(e => e.UpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Topic).WithMany(p => p.ProgressReports)
                .HasForeignKey(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProgressR__Topic__31B762FC");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Result__97690228A2DEDE12");

            entity.ToTable("Result", tb => tb.HasTrigger("trg_UpdateThesisDefenseStatus"));

            entity.HasIndex(e => e.TopicId, "UQ__Result__022E0F7C551C2B0D").IsUnique();

            entity.Property(e => e.ResultId)
                .HasMaxLength(20)
                .HasColumnName("ResultID");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.DefenseScore).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.EvaluationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProcessScore).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.TopicId)
                .HasMaxLength(20)
                .HasColumnName("TopicID");

            entity.HasOne(d => d.Topic).WithOne(p => p.Result)
                .HasForeignKey<Result>(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Result__TopicID__41EDCAC5");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A797D0ECB95");

            entity.ToTable("Student");

            entity.HasIndex(e => e.UserId, "UQ__Student__1788CCAD45E04947").IsUnique();

            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .HasColumnName("StudentID");
            entity.Property(e => e.ClassId)
                .HasMaxLength(20)
                .HasColumnName("ClassID");
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .HasColumnName("UserID");

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Student__ClassID__1AD3FDA4");

            entity.HasOne(d => d.User).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.UserId)
                .HasConstraintName("FK__Student__UserID__19DFD96B");
        });

        modelBuilder.Entity<Thesis>(entity =>
        {
            entity.HasKey(e => e.ThesisId).HasName("PK__Thesis__C2689BC885047B07");

            entity.ToTable("Thesis");

            entity.HasIndex(e => e.TopicId, "UQ__Thesis__022E0F7C3878F9CF").IsUnique();

            entity.Property(e => e.ThesisId)
                .HasMaxLength(20)
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
            entity.Property(e => e.TopicId)
                .HasMaxLength(20)
                .HasColumnName("TopicID");

            entity.HasOne(d => d.Topic).WithOne(p => p.Thesis)
                .HasForeignKey<Thesis>(d => d.TopicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Thesis__TopicID__3B40CD36");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__Topic__022E0F7DB6B91D7B");

            entity.ToTable("Topic");

            entity.Property(e => e.TopicId)
                .HasMaxLength(20)
                .HasColumnName("TopicID");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Chờ duyệt");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SessionId)
                .HasMaxLength(20)
                .HasColumnName("SessionID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .HasColumnName("StudentID");
            entity.Property(e => e.TopicTitle).HasMaxLength(200);

            entity.HasOne(d => d.Session).WithMany(p => p.Topics)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__Topic__SessionID__25518C17");

            entity.HasOne(d => d.Student).WithMany(p => p.Topics)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Topic__StudentID__245D67DE");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC9CB90EE6");

            entity.ToTable("User");

            entity.HasIndex(e => e.IdentityNumber, "UQ__User__6354A73F64033158").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__User__85FB4E38FC3838B1").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D1053418196D7D").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__User__C9F284567C3CB389").IsUnique();

            entity.Property(e => e.UserId)
                .HasMaxLength(20)
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
