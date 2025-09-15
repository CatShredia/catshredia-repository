using System;
using System.Collections.Generic;

namespace TheFirstExampleProject.Data;

public partial class Item
{
    public int IdItem { get; set; }

    public string Name { get; set; } = null!;

    public int Price { get; set; }

    public string? Description { get; set; }
}
