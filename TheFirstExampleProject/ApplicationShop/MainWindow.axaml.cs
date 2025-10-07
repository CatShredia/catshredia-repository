using System;
using ApplicationShop.UserControls;
using ApplicationShop.Windows;
using Avalonia.Controls;
using Avalonia.VisualTree;

namespace ApplicationShop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // create EventHandler if MW is opened to start Auth process
        this.Opened += OnMainWindowOpened;
    }

    private void OnMainWindowOpened(object? sender, EventArgs e)
    {
        this.Opened -= OnMainWindowOpened;

        OpenStartAuth();
    }

    public async void OpenStartAuth()
    {
        var authWindow = new AuthtorizationWindow();
        await authWindow.ShowDialog(this);
    }
    
    
    public void ReplaceControl(Control myControl)
    {
        MainContentArea.Content = myControl;
    }
}