using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TheFirstExampleProject.Data;
using TheFirstExampleProject.Models;
using TheFirstExampleProject.ViewModels;
using TheFirstExampleProject.Views.EditViews;

namespace TheFirstExampleProject.Views;

public partial class UserEditWindow : Window
{
    public UserEditWindow()
    {
        InitializeComponent();
        
        // Загружаем все роли
        var allRoles = App.DbContext.Roles.ToList();
        ComboBoxRoles.ItemsSource = allRoles;

        if (UserVariableData.selectedUser != null)
        {
            DataContext = UserVariableData.selectedLogin;

            // Устанавливаем выбранную роль
            var selectedRole = allRoles.FirstOrDefault(r => r.IdRole == UserVariableData.selectedUser.IdRole);
            ComboBoxRoles.SelectedItem = selectedRole;
        }
        else
        {
            DataContext = new Login();
            
            UserVariableData.selectedLogin = DataContext as Login;
        }
    }

    private void Create_Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (
            string.IsNullOrEmpty(FioTextBox.Text) ||
            string.IsNullOrEmpty(PhoneNumberTextBox.Text) ||
            string.IsNullOrEmpty(DescriptionTextBox.Text) ||
            string.IsNullOrEmpty(LoginTextBox.Text) ||
            string.IsNullOrEmpty(PasswordTextBox.Text) ||
            ComboBoxRoles.SelectedValue == null
        ) return;

        if (UserVariableData.selectedUser != null)
        {
            DataContext = UserVariableData.selectedUser; // <-- User, not Login
        var allRoles = App.DbContext.Roles.ToList();
            var selectedRole = allRoles.FirstOrDefault(r => r.IdRole == UserVariableData.selectedUser.IdRole);
            ComboBoxRoles.SelectedItem = selectedRole;
        }
        else
        {
            DataContext = new User(); // <-- Create new User, not Login
            UserVariableData.selectedUser = DataContext as User; // <-- Store selectedUser, not selectedLogin
        }

        App.DbContext.SaveChanges();

        Close();
    }
}