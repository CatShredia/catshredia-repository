using System;
using System.Collections.Generic;

namespace ApplicationShop.Data;

public partial class Basket
{
    public int IdBasket { get; set; }

    public int IdUser { get; set; }

    public int IdProduct { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
