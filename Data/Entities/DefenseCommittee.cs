using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Data.Entities;

public partial class DefenseCommittee
{
    public Guid CommitteeId { get; set; }

    public string CommitteeName { get; set; } = null!;

    public DateTime EstablishmentDate { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<CommitteeMember> CommitteeMembers { get; set; } = new List<CommitteeMember>();
}
