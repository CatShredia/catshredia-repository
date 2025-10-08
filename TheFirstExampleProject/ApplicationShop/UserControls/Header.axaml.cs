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
        EmployeeButton.IsVisible = false;
        UsersButton.IsVisible = false;
        ProductButton.IsVisible = false;
        CatalogButton.IsVisible = false;
        OrderListButton.IsVisible = false;
        LogOutButton.IsVisible = VariablesData.AuthorizatedUser != null;
        
        // If no user or no role data → exit
        if (VariablesData.AuthorizatedUser?.IdRoleNavigation?.RolePermissions == null)
            return;
        
        // Set visibility based on permissions
        EmployeeButton.IsVisible = VariablesData.PermissionsAuthorizatedUser.Any(p => p.StartsWith("Employee"));
        UsersButton.IsVisible = VariablesData.PermissionsAuthorizatedUser.Any(p => p.StartsWith(("Users")));
        ProductButton.IsVisible = VariablesData.PermissionsAuthorizatedUser.Any(p => p.StartsWith(("Product")));
        CatalogButton.IsVisible = VariablesData.PermissionsAuthorizatedUser.Any(p => p.StartsWith(("Catalog")));
        OrderListButton.IsVisible = VariablesData.PermissionsAuthorizatedUser.Any(p => p.StartsWith(("OrderList"))) && 
                                    VariablesData.AuthorizatedUser.Orders?.Count > 0;
    }

    private async void SelectUserButtonClick(object? sender, RoutedEventArgs e)
    {
        if (VariablesData.AuthorizatedUser == null)
        {
            // user is unauthtorized
            var authWindow = new AuthtorizationWindow();
            await authWindow.ShowDialog(GetWindow());
        }
        else
        {
            VariablesData.SelectedLogin =
                App.DbContext.Logins
                    .FirstOrDefault(login => login.IdUser == VariablesData.AuthorizatedUser.IdUser);

            // user is authtorized
            var userEditWindow = new UsersEditWindow();
            await userEditWindow.ShowDialog(GetWindow());

            VariablesData.SelectedLogin = null;
        }

        UpdateDate();
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

            CheckPermissons();
        }
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
        
        CheckPermissons();

        UpdateDate();
    }
}