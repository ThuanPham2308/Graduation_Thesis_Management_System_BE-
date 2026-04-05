using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Data.Entities;

public partial class CommitteeMember
{
    public Guid CommitteeId { get; set; }

    public Guid LecturerId { get; set; }

    public string Role { get; set; } = null!;

    public virtual DefenseCommittee Committee { get; set; } = null!;

    public virtual Lecturer Lecturer { get; set; } = null!;
}
