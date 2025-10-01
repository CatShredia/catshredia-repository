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

public partial class ProductControl : UserControl
{

    private Window? GetWindow()
    {
        return this.GetVisualRoot() as Window;
    }

    public ProductControl()
    {
        InitializeComponent();

        RefreshDate();
    }

    private async void Show_Product(object? sender, TappedEventArgs e)
    {
        VariablesData.SelectedLogin = UserDataGrid.SelectedItem as Login;

        var editWindow = new ProductEditWindow();
        await editWindow.ShowDialog(GetWindow());

        RefreshDate();
    }

    private async void CreateProduct(object? sender, RoutedEventArgs e)
    {
        var editWindow = new ProductEditWindow();
        await editWindow.ShowDialog(GetWindow());

        RefreshDate();
    }

    private void RefreshDate()
    {
        DataContext = App.DbContext;

        UserDataGrid.ItemsSource =
            App.DbContext.Products
                .ToList();

        if (VariablesData.AuthorizatedUser.IdRole == 1)
        {
            Console.WriteLine("Пользователь - админ");
            UserButtonCreate.IsVisible = true;
        }
        else
        {
            Console.WriteLine("Пользователь - не админ");
        }
    }

    private void DeleteProduct(object? sender, RoutedEventArgs e)
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