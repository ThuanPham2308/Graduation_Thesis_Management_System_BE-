using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Models.Entities;

public partial class OutlinePlan
{
    public string OutlineId { get; set; } = null!;

    public string TopicId { get; set; } = null!;

    public string OutlineContent { get; set; } = null!;

    public string ExecutionPlan { get; set; } = null!;

    public DateTime? SubmissionDate { get; set; }

    public string? Note { get; set; }

    public virtual Topic Topic { get; set; } = null!;
}
