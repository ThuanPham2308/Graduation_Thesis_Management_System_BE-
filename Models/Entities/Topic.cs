using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Models.Entities;

public partial class Topic
{
    public string TopicId { get; set; } = null!;

    public string TopicTitle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string StudentId { get; set; } = null!;

    public string? SessionId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public string? ApprovalStatus { get; set; }

    public virtual ICollection<LecturerAssignment> LecturerAssignments { get; set; } = new List<LecturerAssignment>();

    public virtual ICollection<OutlinePlan> OutlinePlans { get; set; } = new List<OutlinePlan>();

    public virtual ICollection<ProgressReport> ProgressReports { get; set; } = new List<ProgressReport>();

    public virtual Result? Result { get; set; }

    public virtual DefenseSession? Session { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Thesis? Thesis { get; set; }
}
