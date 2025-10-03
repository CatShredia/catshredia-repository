using System.Linq;
using ApplicationShop.Data;

namespace ApplicationShop;

public class VariablesData
{
    // Авторизаванный пользователь
    // public static User AuthorizatedUser { get; set; } = App.DbContext.Users.FirstOrDefault(user => user.IdUser == 1015);
    public static User AuthorizatedUser { get; set; } 

    
    // Выбранные элементы
    public static User SelectedUser { get; set; }
    public static Login SelectedLogin { get; set; }
    public static Product SelectedProduct { get; set; }
    public static Order SelectedOrder { get; set; }
}