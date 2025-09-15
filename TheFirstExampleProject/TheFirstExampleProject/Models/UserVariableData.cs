using TheFirstExampleProject.Data;

namespace TheFirstExampleProject.Models;

public class UserVariableData
{
    public static User selectedUserInMainWindow { get; set; }
    
    public static Login selectedLoginInMainWindow { get; set; }
    
    public static Item selectedItem { get; set; }
}