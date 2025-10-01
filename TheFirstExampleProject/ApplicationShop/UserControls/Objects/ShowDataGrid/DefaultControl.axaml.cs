using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;

namespace ApplicationShop.UserControls;

public partial class DefaultControl : UserControl
{
    public DefaultControl()
    {
        InitializeComponent();
        
        RefreshDate();
    }
    
    private void RefreshDate()
    {
        DataContext = App.DbContext;

        BasketTableDataGrid.ItemsSource =
            App.DbContext.Baskets
                .Include(b => b.IdProductNavigation)
                .Include(b => b.IdUserNavigation)
                .ToList();
    }
}