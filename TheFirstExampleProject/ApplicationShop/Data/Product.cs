using System;
using System.Collections.Generic;

namespace ApplicationShop.Data;

public partial class Product
{
    public int IdProduct { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string? Provider { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual ICollection<OrderList> OrderLists { get; set; } = new List<OrderList>();
}
