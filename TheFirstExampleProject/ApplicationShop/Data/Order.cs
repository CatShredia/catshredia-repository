using System;
using System.Collections.Generic;

namespace ApplicationShop.Data;

public partial class Order
{
    public int IdOrder { get; set; }

    public bool IsPaided { get; set; }

    public bool IsDelivered { get; set; }

    public virtual ICollection<OrderList> OrderLists { get; set; } = new List<OrderList>();
}
