using System;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using TheFirstExampleProject.Data;
using TheFirstExampleProject.Models;
using TheFirstExampleProject.ViewModels;
using TheFirstExampleProject.Views.EditViews;

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

    private async void Show_Login(object? sender, TappedEventArgs e)
    {
        var selectedLogin = LoginDataGrid.SelectedItem as Login;
        Console.WriteLine("Login need " + selectedLogin.IdLogin);
        UserVariableData.selectedLoginInMainWindow = selectedLogin;
        
        var loginEditWindow = new LoginEditWindow();
        await loginEditWindow.ShowDialog(this);
    }

    private async void Create_User_Button(object? sender, RoutedEventArgs e)
    {
        UserVariableData.selectedUserInMainWindow = null;
        
        var userEditWindow = new UserEditWindow();
        userEditWindow.OwnerViewModel = (UserWindowViewModel)this.Resources["UserVM"];;
        await userEditWindow.ShowDialog(this);
    }

    private void Button_User_Delete_OnClick(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var selectedUser = button?.DataContext as User;

        Console.WriteLine((selectedUser == null) ? "User not found" : "User founded");

        if (selectedUser == null) return;

        UserVariableData.selectedUserInMainWindow = selectedUser;
        
        App.DbContext.Users.Remove(selectedUser);
        App.DbContext.SaveChanges();
        
        var viewModel = this.Resources["UserVM"] as UserWindowViewModel;
        viewModel.RefreshData();
    }

    private async void Show_Item(object? sender, TappedEventArgs e)
    {
        var selectedItem = ItemDataGrid.SelectedItem as Item;
        Console.WriteLine("Item need " + selectedItem.IdItem);
        UserVariableData.selectedItem =  selectedItem;
        
        var itemEditWindow = new ItemEditWindow();
        itemEditWindow.OwnerViewModel = (ItemWindowViewModel)this.Resources["ItemVM"];;
        await itemEditWindow.ShowDialog(this);
        
        var viewModel = this.Resources["ItemVM"] as ItemWindowViewModel;
        viewModel.RefreshData();
    }

    private async void Create_Item_Button(object? sender, RoutedEventArgs e)
    {
        UserVariableData.selectedItem = null;
        
        var itemEditWindow = new ItemEditWindow();
        itemEditWindow.OwnerViewModel = (ItemWindowViewModel)this.Resources["ItemVM"];;
        await itemEditWindow.ShowDialog(this);
        
        var viewModel = this.Resources["ItemVM"] as ItemWindowViewModel;
        viewModel.RefreshData();
    }
}