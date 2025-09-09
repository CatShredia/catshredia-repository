using System;
using System.Collections.Generic;
using System.Linq;
using TheFirstExampleProject.Data;

namespace TheFirstExampleProject.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    
    public List<User> Users { get; set; }

    public MainWindowViewModel()
    {
        RefreshData();
    }
    
    public void RefreshData()
    {
        var usersFromDb = App.DbContext.Users.ToList();
        Users = usersFromDb;
        OnPropertyChanged(nameof(Users));
        Console.WriteLine(Users.Count + " users from database");
    }
}