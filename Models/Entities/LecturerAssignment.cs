using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Models.Entities;

public partial class LecturerAssignment
{
    public string TopicId { get; set; } = null!;

    public string LecturerId { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual Lecturer Lecturer { get; set; } = null!;

    public virtual Topic Topic { get; set; } = null!;
}
