using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Models.Entities;

public partial class Student
{
    public string StudentId { get; set; } = null!;

    public string ClassId { get; set; } = null!;

    public int? StudyYear { get; set; }

    public string? UserId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();

    public virtual User? User { get; set; }
}
