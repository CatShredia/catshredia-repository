using System;
using System.Collections.Generic;

namespace TheFirstExampleProject.Data;

public partial class User
{
    public int IdUser { get; set; }

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public DateOnly? DateOfRegistration { get; set; }

    public int IdRole { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
