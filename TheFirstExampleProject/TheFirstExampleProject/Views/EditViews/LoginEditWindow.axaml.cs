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

        if (UserVariableData.selectedLogin != null)
        {
            LoginTextBox.Text = UserVariableData.selectedLogin.Login1;
            PasswordTextBox.Text = UserVariableData.selectedLogin.Password;
        }
    }

    private void Create_Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (UserVariableData.selectedLogin != null)
        {
            Console.WriteLine("Edit login " + UserVariableData.selectedLogin.Login1);

            var idLogin = UserVariableData.selectedLogin.IdLogin;
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