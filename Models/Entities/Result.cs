using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Models.Entities;

public partial class Result
{
    public string ResultId { get; set; } = null!;

    public string TopicId { get; set; } = null!;

    public decimal? ProcessScore { get; set; }

    public decimal? DefenseScore { get; set; }

    public string? Comment { get; set; }

    public DateTime? EvaluationDate { get; set; }

    public virtual Topic Topic { get; set; } = null!;
}
