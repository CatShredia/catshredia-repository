using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using TheFirstExampleProject.Data;
using TheFirstExampleProject.Models;
using TheFirstExampleProject.ViewModels;
using TheFirstExampleProject.Views;

namespace TheFirstExampleProject.UserControls;

public partial class MyUserControl : UserControl
{

    public MyUserControl()
    {
        InitializeComponent();
        
        UserDataGrid.ItemsSource = App.DbContext.Users.ToList();
    }
    
    private Window? GetWindow()
    {
        return this.GetVisualRoot() as Window;
    }
    
    private async void Show_User(object? sender, TappedEventArgs e)
    {
        var selectedUser = UserDataGrid.SelectedItem as User;
        Console.WriteLine("User need " + selectedUser.IdUser);
        UserVariableData.selectedUser = selectedUser;

        var userEditWindow = new UserEditWindow();
        
        await userEditWindow.ShowDialog(GetWindow());
    }
    
    private async void Create_User_Button(object? sender, RoutedEventArgs e)
    {
        UserVariableData.selectedUser = null;

        var userEditWindow = new UserEditWindow();
        await userEditWindow.ShowDialog(GetWindow());
    }

    private void Button_User_Delete_OnClick(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var selectedUser = button?.DataContext as User;

        Console.WriteLine((selectedUser == null) ? "User not found" : "User founded");

        if (selectedUser == null) return;

        UserVariableData.selectedUser = selectedUser;

        App.DbContext.Users.Remove(selectedUser);
        App.DbContext.SaveChanges();

        UserDataGrid.ItemsSource = App.DbContext.Users.ToList();
    }
}