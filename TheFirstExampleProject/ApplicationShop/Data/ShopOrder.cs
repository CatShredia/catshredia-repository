using System;
using System.Collections.Generic;

namespace ApplicationShop.Data;

public partial class ShopOrder
{
    public int IdOrder { get; set; }

    public int IdUser { get; set; }

    public bool IsPaid { get; set; }

    public bool IsDelivered { get; set; }

    public virtual AppUser IdUserNavigation { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
