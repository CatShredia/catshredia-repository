using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;

namespace ApplicationShop.UserControls.Objects.ShowDataGrid;

public partial class AllOrderControl : UserControl
{
    public AllOrderControl()
    {
        InitializeComponent();
        
        DataGridOrders.ItemsSource = App.DbContext.OrderLists
            .Include(list => list.IdOrderNavigation)
                .ThenInclude(order => order.IdUserNavigation)
            .Include(list => list.IdProductNavigation)
            .ToList();
    }
}