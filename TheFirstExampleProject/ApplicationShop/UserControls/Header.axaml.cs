using System;
using System.Linq;
using ApplicationShop.UserControls.Objects;
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
        
        UpdateDate();
    }

    private async void SelectUserButtonClick(object? sender, RoutedEventArgs e)
    {
        if (VariablesData.AuthorizatedUser == null)
        {
            // user is unauthtorized
            var authWindow = new AuthtorizationWindow();
            await authWindow.ShowDialog(GetWindow());

            var parentWindow = GetWindow() as MainWindow;
            parentWindow?.UpdateDate();
            UpdateDate();
        }
        else
        {
            VariablesData.SelectedLogin = App.DbContext.Logins.FirstOrDefault(login => login.IdUser == VariablesData.AuthorizatedUser.IdUser);
            
            // user is authtorized
            var userEditWindow = new UsersEditWindow();
            await userEditWindow.ShowDialog(GetWindow());

            var parentWindow = GetWindow() as MainWindow;
            parentWindow?.UpdateDate();
            UpdateDate();
        }
    }

    public void UpdateDate()
    {
        if (VariablesData.AuthorizatedUser == null) return;
        SelectionUserButton.Content = VariablesData.AuthorizatedUser.Name;
    }

    private void ShowEmployees(object? sender, RoutedEventArgs e)
    {
        var parentWindow = GetWindow() as MainWindow;
        parentWindow?.ReplaceControl(new UsersControl(3));
    }

    private void ShowUsers(object? sender, RoutedEventArgs e)
    {
        var parentWindow = GetWindow() as MainWindow;
        parentWindow?.ReplaceControl(new UsersControl(2));
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
        productWindow?.ReplaceControl(new DefaultControl());
    }
}