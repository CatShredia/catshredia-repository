using System;
using System.Linq;
using ApplicationShop.UserControls;
using ApplicationShop.Windows;
using Avalonia.Controls;
using Avalonia.VisualTree;
using Microsoft.EntityFrameworkCore;

namespace ApplicationShop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        Opened += OnWindowOpened;
    }

    public void ReplaceControl(Control myControl)
    {
        MainContentArea.Content = myControl;
    }

    private void OnWindowOpened(object? sender, EventArgs e)
    {
        OpenAuthWindow();
    }

    private async void OpenAuthWindow()
    {
        // SystemUser(4);

        if (VariablesData.AuthorizatedUser == null)
        {
            var authWindow = new AuthtorizationWindow();
            await authWindow.ShowDialog(this);
        }

        Header.UpdateDate();
    }

    private void SystemUser(int userId)
    {
        VariablesData.AuthorizatedUser = App.DbContext.AppUsers
            .Include(user => user.IdRoleNavigation)
            .ThenInclude(r => r.RolePermissions)
            .FirstOrDefault(user => user.IdRole == userId);

        VariablesData.PermissionsAuthorizatedUser = VariablesData.AuthorizatedUser.IdRoleNavigation.RolePermissions
            .Select(p => p.PermissionName)
            .ToHashSet();
    }
}