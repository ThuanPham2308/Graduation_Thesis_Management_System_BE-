using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Models.Entities;

public partial class DefenseCommittee
{
    public string CommitteeId { get; set; } = null!;

    public string CommitteeName { get; set; } = null!;

    public DateTime EstablishmentDate { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<CommitteeMember> CommitteeMembers { get; set; } = new List<CommitteeMember>();
}
