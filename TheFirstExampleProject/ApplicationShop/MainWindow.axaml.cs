using System;
using ApplicationShop.UserControls;
using Avalonia.Controls;

namespace ApplicationShop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        MainContentArea.Content = new DefaultControl();
    }

    public void UpdateDate()
    {
    }
    
    public void ReplaceControl(Control myControl)
    {
        MainContentArea.Content = myControl;
    }
}