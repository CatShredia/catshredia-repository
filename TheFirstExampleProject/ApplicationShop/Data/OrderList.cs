using System;
using System.Collections.Generic;

namespace ApplicationShop.Data;

public partial class OrderList
{
    public int IdOrderList { get; set; }

    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
