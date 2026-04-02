using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Data.Entities;

public partial class ProgressReport
{
    public Guid ReportId { get; set; }

    public Guid TopicId { get; set; }

    public string? ReportContent { get; set; }

    public string? FilePath { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Comment { get; set; }

    public virtual Topic Topic { get; set; } = null!;
}
