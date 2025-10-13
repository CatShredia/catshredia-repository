using System;
using System.Linq;
using ApplicationShop.Data;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore;

namespace ApplicationShop.Windows.Edit;

public partial class UsersEditWindow : Window
{
    public UsersEditWindow()
    {
        InitializeComponent();
        
        Closing += OnWindowClosing;

        var roles = App.DbContext.Roles.ToList();
        RoleComboBox.ItemsSource = roles;

        if (VariablesData.SelectedLogin == null)
        {
            DataContext = new Login
            {
                IdUserNavigation = new AppUser()
            };

            var defaultRole = roles.FirstOrDefault(r => r.IdRole == VariablesData.SelectedRoleId);
            RoleComboBox.SelectedItem = defaultRole;
        }
        else
        {
            var existingLogin = App.DbContext.Logins
                .Include(l => l.IdUserNavigation)
                .FirstOrDefault(l => l.IdLogin == VariablesData.SelectedLogin.IdLogin);

            if (existingLogin == null)
            {
                Close();
                return;
            }

            DataContext = existingLogin;

            var currentRole = roles.FirstOrDefault(r => r.IdRole == existingLogin.IdUserNavigation.IdRole);
            RoleComboBox.SelectedItem = currentRole;
        }
    }
    
    private void OnWindowClosing(object? sender, WindowClosingEventArgs e)
    {
        VariablesData.SelectedLogin = null;
    }

    private void CreateUser(object? sender, RoutedEventArgs e)
    {
        var login = DataContext as Login;
        var selectedRole = RoleComboBox.SelectedItem as Role;

        if (selectedRole == null && RoleComboBox.IsEnabled)
        {
            return;
        }

        login.IdUserNavigation.IdRole = selectedRole?.IdRole ?? VariablesData.SelectedRoleId;

        try
        {
            if (VariablesData.SelectedLogin == null)
            {
                App.DbContext.Logins.Add(login);
            }

            App.DbContext.SaveChanges();
            VariablesData.SelectedLogin = null;
            Close();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Ошибка сохранения: {ex.Message}");
        }

        VariablesData.SelectedLogin = null;
    }
}