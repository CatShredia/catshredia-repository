using System;
using System.Collections.Generic;

namespace ApplicationShop.Data;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdUser { get; set; }

    public bool IsPaided { get; set; }

    public bool IsDelivered { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<OrderList> OrderLists { get; set; } = new List<OrderList>();
}
