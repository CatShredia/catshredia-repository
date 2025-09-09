using System;
using System.Collections.Generic;
using System.Linq;
using TheFirstExampleProject.Data;

namespace TheFirstExampleProject.ViewModels;

public class LoginWindowViewModel : ViewModelBase
{
    public List<Login> Logins { get; set; }

    public LoginWindowViewModel()
    {
        RefreshData();
    }
    
    public void RefreshData()
    {
        var loginsFromDb = App.DbContext.Logins.ToList();
        Logins = loginsFromDb;
        OnPropertyChanged(nameof(Logins));
        Console.WriteLine(Logins.Count + " logins from database");
    }
}