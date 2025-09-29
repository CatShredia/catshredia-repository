using System;
using System.Linq;
using ApplicationShop.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ApplicationShop.Windows;

public partial class AuthtorizationWindow : Window
{
    public AuthtorizationWindow()
    {
        InitializeComponent();
    }

    private void AuthUser(object? sender, RoutedEventArgs e)
    {
        if (VariablesData.AuthorizatedUser == null)
        {
            var selectedLogin = App.DbContext.Logins.FirstOrDefault(login =>
                login.Login1 == LoginTextBox.Text &&
                login.Password == PasswordTextBox.Text
            );
            if (selectedLogin == null)
            {
                Console.WriteLine("Login not found");
            }
            else
            {
                var selectedUser = App.DbContext.Users.FirstOrDefault(user => selectedLogin.IdUser == user.IdUser);
                VariablesData.AuthorizatedUser = selectedUser;
            }
        }

        Close();
    }
}