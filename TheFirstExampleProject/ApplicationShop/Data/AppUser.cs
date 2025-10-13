using System;
using System.Collections.Generic;

namespace ApplicationShop.Data;

public partial class AppUser
{
    public int IdUser { get; set; }

    public string? Surname { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Phone { get; set; }

    public int IdRole { get; set; }

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual ICollection<ShopOrder> ShopOrders { get; set; } = new List<ShopOrder>();

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
}
