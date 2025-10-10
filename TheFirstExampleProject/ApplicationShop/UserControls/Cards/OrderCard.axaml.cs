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
        if (DataContext is Order order)
        {
            LoadOrderProducts(order);
        }
        else
        {
            ProductDataGrid.ItemsSource = null;
        }
    }

    private void LoadOrderProducts(Order order)
    {
        // Загружаем OrderLists с продуктами для этого заказа
        var orderLists = App.DbContext.OrderLists
            .Include(ol => ol.IdProductNavigation)
            .Include(list => list.IdOrderNavigation)
                .ThenInclude(user => user.IdUserNavigation)
            .Where(ol => ol.IdOrder == order.IdOrder)
            .ToList();

        ProductDataGrid.ItemsSource = orderLists;
    }
}