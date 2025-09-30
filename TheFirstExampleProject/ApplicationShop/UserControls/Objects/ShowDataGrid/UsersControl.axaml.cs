using System;
using System.Linq;
using ApplicationShop.Data;
using ApplicationShop.Windows.Edit;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Microsoft.EntityFrameworkCore;

namespace ApplicationShop.UserControls.Objects;

public partial class UsersControl : UserControl
{
    public static int IdCurrentRole;

    private Window? GetWindow()
    {
        return this.GetVisualRoot() as Window;
    }

    public UsersControl(int idCurrentRole)
    {
        InitializeComponent();

        IdCurrentRole = idCurrentRole;

        RefreshDate();
    }

    private async void Show_Employee(object? sender, TappedEventArgs e)
    {
        VariablesData.SelectedLogin = UserDataGrid.SelectedItem as Login;

        var editWindow = new UsersEditWindow();
        await editWindow.ShowDialog(GetWindow());

        RefreshDate();
    }

    private async void CreateEmployee(object? sender, RoutedEventArgs e)
    {
        var editWindow = new UsersEditWindow();
        await editWindow.ShowDialog(GetWindow());

        RefreshDate();
    }

    private void RefreshDate()
    {
        DataContext = App.DbContext;

        UserDataGrid.ItemsSource =
            App.DbContext.Logins
                .Include(login => login.IdUserNavigation)
                .Where(login => login.IdUserNavigation.IdRole == IdCurrentRole)
                .ToList();

        if (VariablesData.AuthorizatedUser.IdRole == 1 && IdCurrentRole == 3)
        {
            Console.WriteLine("Пользователь - админ");
            UserButtonCreate.IsVisible = true;
        }
        else
        {
            Console.WriteLine("Пользователь - не админ");
        }
    }

    private void DeleteEmployee(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var selectedLogin = button?.DataContext as Login;

        Console.WriteLine((selectedLogin == null) ? "User not found" : "User founded");

        if (selectedLogin == null) return;

        VariablesData.SelectedLogin = selectedLogin;

        App.DbContext.Logins.Remove(selectedLogin);
        App.DbContext.SaveChanges();

        RefreshDate();
    }
}