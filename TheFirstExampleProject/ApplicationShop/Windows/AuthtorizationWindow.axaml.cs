using System;
using System.Linq;
using ApplicationShop.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationShop.Windows;

public partial class AuthtorizationWindow : Window
{
    public AuthtorizationWindow()
    {
        InitializeComponent();
    }

    private bool ValidateData()
    {
        LoginValidationErrorBlock.Text = string.Empty;
        PasswordValidationErrorBlock.Text = string.Empty;
        ValidationErrorBlock.Text = string.Empty;
        
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(LoginTextBox?.Text))
        {
            LoginValidationErrorBlock.Text = "Please enter a username.";
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(PasswordTextBox?.Text))
        {
            PasswordValidationErrorBlock.Text = "Please enter a password.";
            isValid = false;
        }
        // ! explore code
        // else if (PasswordTextBox.Text.Length < 8)
        // {
        //     PasswordValidationErrorBlock.Text = "Password must be at least 8 characters long.";
        //     isValid = false;
        // }

        return isValid;
    }

    private void AuthUser(object? sender, RoutedEventArgs e)
    {
        if (!ValidateData()) return;

        if (VariablesData.AuthorizatedUser == null)
        {
            var selectedLogin = App.DbContext.Logins
                .FirstOrDefault(login =>
                    login.Login1 == LoginTextBox.Text &&
                    login.Password == PasswordTextBox.Text
                );
            if (selectedLogin != null)
            {
                var selectedUser = App.DbContext.Users
                    .Include(user => user.IdRoleNavigation)
                    .ThenInclude(r => r.RolePermissions)
                    .FirstOrDefault(user => selectedLogin.IdUser == user.IdUser);
                VariablesData.AuthorizatedUser = selectedUser;
                
                VariablesData.PermissionsAuthorizatedUser = VariablesData.AuthorizatedUser.IdRoleNavigation.RolePermissions
                    .Select(p => p.PermissionName)
                    .ToHashSet(); // Fast lookup
                
                Close();
            }
        }

        if (VariablesData.AuthorizatedUser == null)
        {
            ValidationErrorBlock.Text = "Incorrect username or password.";
        }
    }
}