using System;
using System.Collections.Generic;

namespace Graduation_Thesis_Management_System_BE.Models.Entities;

public partial class User
{
    public Guid UserId { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Hometown { get; set; } = null!;

    public string? Avatar { get; set; }

    public string IdentityNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual Admin? Admin { get; set; }

    public virtual Lecturer? Lecturer { get; set; }

    public virtual Student? Student { get; set; }
}
