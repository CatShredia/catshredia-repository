using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TheFirstExampleProject.Views.EditViews;

namespace TheFirstExampleProject.Views;

public partial class LoginsTableWindow : Window
{
    public LoginsTableWindow()
    {
        InitializeComponent();
    }

    private async void Show_Login(object? sender, TappedEventArgs e)
    {
        var loginEditWindow = new LoginEditWindow();
        await loginEditWindow.ShowDialog(this);
    }

    private void Create_Login_Button(object? sender, RoutedEventArgs e)
    {
        
    }
}