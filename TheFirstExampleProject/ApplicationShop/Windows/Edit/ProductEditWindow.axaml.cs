using System;
using System.Linq;
using ApplicationShop.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ApplicationShop.Windows.Edit;

public partial class ProductEditWindow : Window
{
    public ProductEditWindow()
    {
        InitializeComponent();

        if (VariablesData.SelectedLogin == null)
        {
            DataContext = new Login()
            {
                IdUserNavigation = new User()
            };
        }
        else
        {
            DataContext = VariablesData.SelectedLogin;
        }
    }

    private void CreateUser(object? sender, RoutedEventArgs e)
    {
        var loginDataContext = DataContext as Login;
        loginDataContext.IdUserNavigation.IdRoleNavigation = App.DbContext.Roles.FirstOrDefault(role => role.Name == "employee");

        if (loginDataContext.IdUserNavigation.IdRoleNavigation == null)
        {
            Console.WriteLine("Роли нет");
            return;
        }
        
        if (VariablesData.SelectedLogin == null)
        {
            App.DbContext.Logins.Add(loginDataContext);
        }
        else
        {
            App.DbContext.Update(loginDataContext);
        }
        
        App.DbContext.SaveChanges();
        Close();
    }
}