using System;
using System.Collections.ObjectModel;
using System.Linq;
using TheFirstExampleProject.Data;

namespace TheFirstExampleProject.ViewModels;

public class RoleWindowViewModel
{
    public ObservableCollection<Role> Roles { get; set; }

    public RoleWindowViewModel()
    {
        RefreshData();
    }
    
    public void RefreshData()
    {
        Roles = new ObservableCollection<Role>(App.DbContext.Roles.ToList());
        Console.WriteLine(Roles.Count + " users from database");
    }
}