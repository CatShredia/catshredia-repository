using System;
using System.Linq;
using ApplicationShop.UserControls.Objects;
using ApplicationShop.UserControls.Objects.ShowDataGrid;
using ApplicationShop.Windows;
using ApplicationShop.Windows.Edit;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace ApplicationShop.UserControls;

public partial class Header : UserControl
{
    private Window? GetWindow()
    {
        return this.GetVisualRoot() as Window;
    }

    public Header()
    {
        InitializeComponent();

        UpdateDate();
    }

    private void CheckPermissons()
    {

    }

    private async void SelectUserButtonClick(object? sender, RoutedEventArgs e)
    {
        if (VariablesData.AuthorizatedUser == null)
        {
            // user is unauthtorized
            var authWindow = new AuthtorizationWindow();
            await authWindow.ShowDialog(GetWindow());
            
            UpdateDate();
        }
        else
        {
            VariablesData.SelectedLogin =
                App.DbContext.Logins.FirstOrDefault(login => login.IdUser == VariablesData.AuthorizatedUser.IdUser);

            // user is authtorized
            var userEditWindow = new UsersEditWindow();
            await userEditWindow.ShowDialog(GetWindow());
            
            UpdateDate();
            VariablesData.SelectedLogin = null;
        }
    }

    public void UpdateDate()
    {
        if (VariablesData.AuthorizatedUser == null)
        {
            // user is unauthtorized
            SelectionUserButton.Content = "Login";
        }
        else
        {
            // user is authtorized
            SelectionUserButton.Content = VariablesData.AuthorizatedUser.Name;
        }

        CheckPermissons();
    }

    private void ShowEmployees(object? sender, RoutedEventArgs e)
    {
        var parentWindow = GetWindow() as MainWindow;
        VariablesData.SelectedRoleId = 2;
        parentWindow?.ReplaceControl(new UsersControl());
    }

    private void ShowUsers(object? sender, RoutedEventArgs e)
    {
        var parentWindow = GetWindow() as MainWindow;
        VariablesData.SelectedRoleId = 3;
        parentWindow?.ReplaceControl(new UsersControl());
    }

    private void ShowProduct(object? sender, RoutedEventArgs e)
    {
        var productWindow = GetWindow() as MainWindow;
        productWindow?.ReplaceControl(new ProductControl());
    }

    private void ShowCatalog(object? sender, RoutedEventArgs e)
    {
        var catalogWindow = GetWindow() as MainWindow;
        catalogWindow?.ReplaceControl(new CatalogControl());
    }

    private void ShowDefault(object? sender, RoutedEventArgs e)
    {
        var productWindow = GetWindow() as MainWindow;
        productWindow?.ReplaceControl(new DefaultControl(this));
    }

    private void ShowUserOrders(object? sender, RoutedEventArgs e)
    {
        var productWindow = GetWindow() as MainWindow;
        productWindow?.ReplaceControl(new OrderControl());
    }

    private void LogOutButton_OnClick(object? sender, RoutedEventArgs e)
    {
        VariablesData.AuthorizatedUser = null;
        
        var parentWindow = GetWindow() as MainWindow;
        parentWindow?.ReplaceControl(new DefaultControl(this));

        UpdateDate();
    }
}