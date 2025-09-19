using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using TheFirstExampleProject.Data;
using TheFirstExampleProject.Models;
using TheFirstExampleProject.ViewModels;
using TheFirstExampleProject.Views.EditViews;

namespace TheFirstExampleProject.UserControls;

public partial class LoginControl : UserControl
{
    public LoginControl()
    {
        InitializeComponent();
        
        LoginDataGrid.ItemsSource = App.DbContext.Logins.ToList();
    }
    
    private Window? GetWindow()
    {
        return this.GetVisualRoot() as Window;
    }

    private async void Show_Login(object? sender, TappedEventArgs e)
    {
        var selectedLogin = LoginDataGrid.SelectedItem as Login;
        Console.WriteLine("Login need " + selectedLogin.IdLogin);
        UserVariableData.selectedLogin = selectedLogin;

        var loginEditWindow = new LoginEditWindow();
        await loginEditWindow.ShowDialog(GetWindow());
    }
}