using System;
using System.Linq;
using ApplicationShop.Data;
using ApplicationShop.Windows;
using ApplicationShop.Windows.Edit;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Microsoft.EntityFrameworkCore;

namespace ApplicationShop.UserControls.Objects.ShowDataGrid;

public partial class OrderControl : UserControl
{
    private Window? GetWindow()
    {
        return this.GetVisualRoot() as Window;
    }

    public OrderControl()
    {
        InitializeComponent();

        RefreshDate();
    }

    private async void Show_Order(object? sender, TappedEventArgs e)
    {
        RefreshDate();
    }

    private void RefreshDate()
    {
        var orders = App.DbContext.ShopOrders
            .Where(o => o.IdUser == VariablesData.AuthorizatedUser.IdUser)
            .ToList();

        OrdersItemsControl.ItemsSource = orders;
    }
}