using ApplicationShop.UserControls.Objects;
using ApplicationShop.Windows;
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
    }

    public void UpdateDate()
    {
        SelectionUserButton.Content = VariablesData.AuthorizatedUser.Name;
    }

    private void ShowEmployees(object? sender, RoutedEventArgs e)
    {
        var parentWindow = GetWindow() as MainWindow;
        parentWindow?.ReplaceControl(new EmployeeControl());
    }
}