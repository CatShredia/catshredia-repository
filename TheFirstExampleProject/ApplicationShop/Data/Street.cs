using System;
using System.Collections.Generic;

namespace ApplicationShop.Data;

public partial class Street
{
    public int IdStreet { get; set; }

    public string Name { get; set; } = null!;

    public int IdCity { get; set; }

    public virtual City IdCityNavigation { get; set; } = null!;

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
}
