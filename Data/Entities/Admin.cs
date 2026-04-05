using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Data.Entities;

public partial class Admin
{
    public Guid AdminId { get; set; }

    public Guid? UserId { get; set; }

    public virtual User? User { get; set; }
}
