using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;

namespace ApplicationShop.UserControls;

public partial class DefaultControl : UserControl
{

    public DefaultControl(Header header)
    {
        InitializeComponent();
        
        RefreshDate();
    }
    
    private void RefreshDate()
    {
        DataContext = App.DbContext;
    }   
}