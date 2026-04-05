using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Data.Entities;

public partial class Student
{
    public Guid StudentId { get; set; }

    public Guid ClassId { get; set; }

    public int? StudyYear { get; set; }

    public Guid? UserId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();

    public virtual User? User { get; set; }
}
