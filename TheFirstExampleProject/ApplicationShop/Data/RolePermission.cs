using System;
using System.Collections.Generic;

namespace ApplicationShop.Data;

public partial class RolePermission
{
    public int IdRole { get; set; }

    public string PermissionName { get; set; } = null!;

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
