using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Models.Entities;

public partial class ProgressReport
{
    public string ReportId { get; set; } = null!;

    public string TopicId { get; set; } = null!;

    public string? ReportContent { get; set; }

    public string? FilePath { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Comment { get; set; }

    public virtual Topic Topic { get; set; } = null!;
}
