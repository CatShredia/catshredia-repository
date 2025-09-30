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

public partial class EmployeeControl : UserControl
{
    private Window? GetWindow()
    {
        return this.GetVisualRoot() as Window;
    }

    public EmployeeControl()
    {
        InitializeComponent();

        RefreshDate();
    }

    private async void Show_Employee(object? sender, TappedEventArgs e)
    {
        VariablesData.SelectedLogin = UserDataGrid.SelectedItem as Login;

        var editWindow = new EmployeeEditWindow();
        await editWindow.ShowDialog(GetWindow());
        
        RefreshDate();
    }

    private async void CreateEmployee(object? sender, RoutedEventArgs e)
    {
        var editWindow = new EmployeeEditWindow();
        await editWindow.ShowDialog(GetWindow());
        
        RefreshDate();
    }

    private void RefreshDate()
    {
        DataContext = App.DbContext;
        
        UserDataGrid.ItemsSource =
            App.DbContext.Logins
                .Include(login => login.IdUserNavigation)
                .Where(login => login.IdUserNavigation.IdRole == 3)
                .ToList();
    }
}