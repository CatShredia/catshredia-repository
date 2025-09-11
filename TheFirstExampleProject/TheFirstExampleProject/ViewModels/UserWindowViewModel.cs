using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TheFirstExampleProject.Data;

namespace TheFirstExampleProject.ViewModels;

public class UserWindowViewModel : ViewModelBase
{
    
    public ObservableCollection<User> Users { get; set; }

    public UserWindowViewModel()
    {
        RefreshData();
    }
    
    public void RefreshData()
    {
        Users = new ObservableCollection<User>(App.DbContext.Users.ToList());
        OnPropertyChanged(nameof(Users));
        Console.WriteLine(Users.Count + " users from database");
    }
}