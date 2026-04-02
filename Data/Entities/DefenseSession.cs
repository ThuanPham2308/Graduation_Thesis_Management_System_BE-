using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Data.Entities;

public partial class DefenseSession
{
    public Guid SessionId { get; set; }

    public string SessionName { get; set; } = null!;

    public string AcademicYear { get; set; } = null!;

    public string? Semester { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
}
