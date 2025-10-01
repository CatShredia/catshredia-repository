using System;
using System.Linq;
using ApplicationShop.Data;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ApplicationShop.Windows.Edit;

public partial class ProductEditWindow : Window
{
    public ProductEditWindow()
    {
        InitializeComponent();

        if (VariablesData.SelectedProduct == null)
        {
            DataContext = new Product();
        }
        else
        {
            DataContext = VariablesData.SelectedProduct;
        }
    }

    private void CreateUser(object? sender, RoutedEventArgs e)
    {
        var productDataContext = DataContext as Product;
        
        if (VariablesData.SelectedProduct == null)
        {
            App.DbContext.Products.Add(productDataContext);
        }
        else
        {
            App.DbContext.Update(productDataContext);
        }
        
        App.DbContext.SaveChanges();
        Close();
    }
}