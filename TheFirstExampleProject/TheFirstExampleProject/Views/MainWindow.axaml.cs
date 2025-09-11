using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using TheFirstExampleProject.Data;
using TheFirstExampleProject.Models;
using TheFirstExampleProject.ViewModels;

namespace TheFirstExampleProject.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        DataContext = new MainWindowViewModel();
    }

    private async void Show_User(object? sender, TappedEventArgs e)
    {
        var selectedUser = UserDataGrid.SelectedItem as User;
        Console.WriteLine("User need " + selectedUser.IdUser);
        UserVariableData.selectedUserInMainWindow =  selectedUser;
        
        var userEditWindow = new UserEditWindow();
        userEditWindow.OwnerViewModel = (UserWindowViewModel)this.Resources["UserVM"];;
        await userEditWindow.ShowDialog(this);
    }

    private void Show_Login(object? sender, TappedEventArgs e)
    {
        
    }

    private async void Create_User_Button(object? sender, RoutedEventArgs e)
    {
        UserVariableData.selectedUserInMainWindow = null;
        
        var userEditWindow = new UserEditWindow();
        userEditWindow.OwnerViewModel = (UserWindowViewModel)this.Resources["UserVM"];;
        await userEditWindow.ShowDialog(this);
    }
}