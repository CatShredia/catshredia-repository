using System.Linq;
using ApplicationShop.Data;

namespace ApplicationShop;

public class VariablesData
{
    public static User AuthorizatedUser { get; set; } = App.DbContext.Users.FirstOrDefault(user => user.IdUser == 1015);
    // public static User AuthorizatedUser { get; set; } 

    
    public static User SelectedUser { get; set; }
    
    public static Login SelectedLogin { get; set; }
    public static Product SelectedProduct { get; set; }
}