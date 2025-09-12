using System;
using System.Collections.Generic;

namespace TheFirstExampleProject.Data;

public partial class User
{
    public int IdUser { get; set; }

    public string Fio { get; set; } = null!;

    public int IdRole { get; set; }

    public string? Description { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
