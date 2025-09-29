using System;
using System.Collections.Generic;

namespace ApplicationShop.Data;

public partial class UserAdress
{
    public int IdUserAdress { get; set; }

    public int IdUser { get; set; }

    public int IdStreet { get; set; }

    public string Home { get; set; } = null!;

    public int? Apartment { get; set; }

    public virtual Street IdStreetNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
