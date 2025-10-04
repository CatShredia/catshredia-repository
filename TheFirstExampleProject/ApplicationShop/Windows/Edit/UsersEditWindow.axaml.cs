using System;
using System.Linq;
using ApplicationShop.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ApplicationShop.Windows.Edit;

public partial class UsersEditWindow : Window
{
    public UsersEditWindow()
    {
        InitializeComponent();

        RoleComboBox.ItemsSource = App.DbContext.Roles.ToList();
        RoleComboBox.SelectedItem = VariablesData.SelectedRoleId;

        if (VariablesData.SelectedLogin == null)
        {
            DataContext = new Login()
            {
                IdUserNavigation = new User()
            };
            RoleComboBox.SelectedItem = App.DbContext.Roles.FirstOrDefault(role => role.IdRole == VariablesData.SelectedRoleId);
        }
        else
        {
            DataContext = VariablesData.SelectedLogin;
            RoleComboBox.SelectedItem = VariablesData.SelectedLogin.IdUserNavigation.IdRoleNavigation;
        }
    }

    private void CreateUser(object? sender, RoutedEventArgs e)
    {
        var loginDataContext = DataContext as Login;
        loginDataContext.IdUserNavigation.IdRoleNavigation =
            App.DbContext.Roles.FirstOrDefault(role => role.IdRole == VariablesData.SelectedRoleId);

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
        
        VariablesData.SelectedLogin = null;
        
        Close();
    }
}