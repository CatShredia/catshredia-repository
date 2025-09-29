using System;
using System.Collections.Generic;

namespace ApplicationShop.Data;

public partial class City
{
    public int IdCity { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
}
