using System;
using System.Linq;
using ApplicationShop.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;

namespace ApplicationShop.UserControls.Cards;

public partial class OrderCard : UserControl
{
    public OrderCard()
    {
        InitializeComponent();
        DataContextChanged += OnDataContextChanged;
    }

    private void OnDataContextChanged(object sender, EventArgs e)
    {
        if (DataContext is ShopOrder order)
        {
            LoadOrderProducts(order);
        }
        else
        {
            ProductDataGrid.ItemsSource = null;
        }
    }

    private void LoadOrderProducts(ShopOrder order)
    {
        // Загружаем OrderLists с продуктами для этого заказа
        var orderLists = App.DbContext.OrderItems
            .Include(ol => ol.IdProductNavigation)
            .Include(list => list.IdOrderNavigation)
                .ThenInclude(user => user.IdUserNavigation)
            .Where(ol => ol.IdOrder == order.IdOrder)
            .ToList();

        ProductDataGrid.ItemsSource = orderLists;
    }
}