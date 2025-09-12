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

        DataContext = new LoginWindowViewModel();

        if (LoginVariableData.selectedLoginInMainWindow != null)
        {
            LoginTextBox.Text = LoginVariableData.selectedLoginInMainWindow.Login1;
            PasswordTextBox.Text = LoginVariableData.selectedLoginInMainWindow.Password;
        }
    }

    private void Create_Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (LoginVariableData.selectedLoginInMainWindow != null)
        {
            Console.WriteLine("Edit login " + LoginVariableData.selectedLoginInMainWindow.Login1);

            var idLogin = LoginVariableData.selectedLoginInMainWindow.IdLogin;
            var selectedLogin = App.DbContext.Logins.FirstOrDefault(x => x.IdLogin == idLogin);

            if (selectedLogin == null) return;

            selectedLogin.Login1 = LoginTextBox.Text;
            selectedLogin.Password = PasswordTextBox.Text;
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

        var viewModel = DataContext as LoginWindowViewModel; 
        viewModel.RefreshData();
        
        Close();
    }
}