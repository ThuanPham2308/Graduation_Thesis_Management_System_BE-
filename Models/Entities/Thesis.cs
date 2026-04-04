using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Models.Entities;

public partial class Thesis
{
    public Guid ThesisId { get; set; }

    public Guid TopicId { get; set; } 

    public DateTime? SubmissionDate { get; set; }

    public string? FilePath { get; set; }

    public string? Description { get; set; }

    public string? ApprovalStatus { get; set; }

    public string? DefenseConfirmation { get; set; }

    public string? DefenseStatus { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public virtual Topic Topic { get; set; } = null!;
}
