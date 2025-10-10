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

        RefreshDate();
    }

    private void RefreshDate()
    {
        var orders = App.DbContext.Orders
            .ToList();

        OrdersItemsControl.ItemsSource = orders;
    }
}