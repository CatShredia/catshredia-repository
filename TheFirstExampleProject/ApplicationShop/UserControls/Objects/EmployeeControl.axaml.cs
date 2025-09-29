using System;
using System.Linq;
using ApplicationShop.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;

namespace ApplicationShop.UserControls.Objects;

public partial class EmployeeControl : UserControl
{
    public EmployeeControl()
    {
        InitializeComponent();
        
        foreach (var elem in App.DbContext.Users
                     .Where(user => user.IdRoleNavigation.IdRole == 3).ToList())
        {
            Console.WriteLine("Имя: " + elem.Name);
        }
            
        UserDataGrid.ItemsSource = 
            App.DbContext.Users
                .Where(user => user.IdRoleNavigation.IdRole == 3).ToList();
        
        Console.WriteLine("1");

        Console.WriteLine(UserDataGrid);
    }

    private void Show_Employee(object? sender, TappedEventArgs e)
    {

    }
}