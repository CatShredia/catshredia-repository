using System;
using System.Linq;
using ApplicationShop.Data;
using ApplicationShop.Windows.Edit;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using Microsoft.EntityFrameworkCore;

namespace ApplicationShop.UserControls.Objects;

public partial class ProductControl : UserControl
{

    private Window? GetWindow()
    {
        return this.GetVisualRoot() as Window;
    }

    public ProductControl()
    {
        InitializeComponent();

        RefreshDate();
    }

    private async void Show_Product(object? sender, TappedEventArgs e)
    {
        VariablesData.SelectedProduct = ProductDataGrid.SelectedItem as Product;

        var editWindow = new ProductEditWindow();
        await editWindow.ShowDialog(GetWindow());

        RefreshDate();
    }

    private async void CreateProduct(object? sender, RoutedEventArgs e)
    {
        var editWindow = new ProductEditWindow();
        await editWindow.ShowDialog(GetWindow());
        
        VariablesData.SelectedProduct = null;

        RefreshDate();
    }

    private void RefreshDate()
    {
        DataContext = App.DbContext;

        ProductDataGrid.ItemsSource =
            App.DbContext.Products
                .ToList();
    }

    private void DeleteProduct(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var selectedProduct = button?.DataContext as Product;

        if (selectedProduct == null) return;

        VariablesData.SelectedProduct = selectedProduct;

        App.DbContext.Products.Remove(selectedProduct);
        App.DbContext.SaveChanges();

        RefreshDate();
    }
}