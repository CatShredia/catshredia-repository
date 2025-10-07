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
    }
    
    
    public void ReplaceControl(Control myControl)
    {
        MainContentArea.Content = myControl;
    }
}