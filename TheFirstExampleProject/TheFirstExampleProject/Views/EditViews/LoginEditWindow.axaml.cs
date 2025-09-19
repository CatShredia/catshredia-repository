using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TheFirstExampleProject.Data;
using TheFirstExampleProject.Models;
using TheFirstExampleProject.ViewModels;

namespace TheFirstExampleProject.Views.EditViews;

public partial class LoginEditWindow : Window
{
    public LoginEditWindow()
    {
        InitializeComponent();

        DataContext = UserVariableData.selectedLogin;

        // if (UserVariableData.selectedLogin != null)
        // {
        //     LoginTextBox.Text = UserVariableData.selectedLogin.Login1;
        //     PasswordTextBox.Text = UserVariableData.selectedLogin.Password;
        // }
    }

    private void Create_Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (UserVariableData.selectedLogin != null)
        {
            Console.WriteLine("Edit login " + UserVariableData.selectedLogin.IdLogin);

            var idLogin = UserVariableData.selectedLogin.IdLogin;
            var selectedLogin = App.DbContext.Logins.FirstOrDefault(x => x.IdLogin == idLogin);
            
            var loginChange = DataContext as Login;
            selectedLogin = loginChange;
        }
        else
        {
            Console.WriteLine("Create new login");

            var newLogin = new Login()
            {
                Login1 = LoginTextBox.Text,
                Password = PasswordTextBox.Text,
            };
            App.DbContext.Logins.Add(newLogin);
        }

        App.DbContext.SaveChanges();
        
        Close();
    }
}