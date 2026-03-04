using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Models.Entities;

public partial class Admin
{
    public string AdminId { get; set; } = null!;

    public string? UserId { get; set; }

    public virtual User? User { get; set; }
}
