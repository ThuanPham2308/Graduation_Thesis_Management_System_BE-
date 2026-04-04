using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Models.Entities;

public partial class LecturerAssignment
{
    public Guid TopicId { get; set; } 

    public Guid LecturerId { get; set; } 

    public string Role { get; set; } = null!;

    public virtual Lecturer Lecturer { get; set; } = null!;

    public virtual Topic Topic { get; set; } = null!;
}
