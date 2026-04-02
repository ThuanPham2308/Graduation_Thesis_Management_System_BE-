using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Data.Entities;

public partial class Class
{
    public Guid ClassId { get; set; }

    public Guid LecturerId { get; set; }

    public string ClassName { get; set; } = null!;

    public string Cohort { get; set; } = null!;

    public string AcademicYear { get; set; } = null!;

    public string? Note { get; set; }

    public virtual Lecturer Lecturer { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
