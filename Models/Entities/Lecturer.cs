using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Models.Entities;

public partial class Lecturer
{
    public Guid LecturerId { get; set; }

    public string Position { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public string AcademicDegree { get; set; } = null!;

    public Guid UserId { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<CommitteeMember> CommitteeMembers { get; set; } = new List<CommitteeMember>();

    public virtual ICollection<LecturerAssignment> LecturerAssignments { get; set; } = new List<LecturerAssignment>();

    public virtual User? User { get; set; }
}
