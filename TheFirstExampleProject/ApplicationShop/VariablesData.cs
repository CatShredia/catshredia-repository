using System.Collections.Generic;
using System.Linq;
using ApplicationShop.Data;

namespace ApplicationShop;

public class VariablesData
{
    // Авторизаванный пользователь
    public static User AuthorizatedUser { get; set; }
    // Разрешения авторизаванного пользователя
    public static HashSet<string> PermissionsAuthorizatedUser { get; set; }


    // Выбранные элементы
    public static User SelectedUser { get; set; }
    public static Login SelectedLogin { get; set; }
    public static Product SelectedProduct { get; set; }
    public static Order SelectedOrder { get; set; }
    
    public static int SelectedRoleId { get; set; }
}