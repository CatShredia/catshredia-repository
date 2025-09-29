using System;
using System.Collections.Generic;

namespace ApplicationShop.Data;

public partial class User
{
    public int IdUser { get; set; }

    public string? Surname { get; set; }

    public string Name { get; set; } = null!;

    public string? Desciption { get; set; }

    public string? Phone { get; set; }

    public int IdRole { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual ICollection<UserAdress> UserAdresses { get; set; } = new List<UserAdress>();

    public virtual ICollection<Product> IdProducts { get; set; } = new List<Product>();
}
