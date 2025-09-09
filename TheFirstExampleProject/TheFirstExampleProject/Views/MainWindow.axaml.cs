using System;
using Avalonia.Controls;
using Avalonia.Input;
using TheFirstExampleProject.Data;
using TheFirstExampleProject.ViewModels;

namespace TheFirstExampleProject.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        DataContext = new MainWindowViewModel();
    }

    private void Show_User(object? sender, TappedEventArgs e)
    {
        var selectedUser = UserDataGrid.SelectedItem as User;
        Console.WriteLine("User need " + selectedUser.IdUser);
    }

    private void Show_Login(object? sender, TappedEventArgs e)
    {
        
    }
}