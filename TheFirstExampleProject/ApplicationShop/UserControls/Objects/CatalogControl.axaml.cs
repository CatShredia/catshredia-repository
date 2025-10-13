using System;
using System.Collections.Generic;
using System.ComponentModel;
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

public partial class CatalogControl : UserControl
{
    // Data
    private static List<CatalogItem> allCatalogProducts;
    private static List<CatalogItem> selectedCatalogProducts;
    
    private ListSortDirection _sortDirection = ListSortDirection.Ascending;
    
    // filters
    private string _sortColumn = "IdOrderList";

    //only filters
    private void ApplyFiltersAndSort()
    {
        // Фильтрация
        var query = allCatalogProducts.AsQueryable();

        var searchText = SearchBox?.Text?.Trim();
        if (!string.IsNullOrEmpty(searchText))
        {
            query = query.Where(item =>
                item.Name.Contains(searchText, System.StringComparison.OrdinalIgnoreCase)
            );
        }

        selectedCatalogProducts = query.ToList();

        CatalogDataGrid.ItemsSource = selectedCatalogProducts;
    }
    
    private Window? GetWindow()
    {
        return this.GetVisualRoot() as Window;
    }

    public CatalogControl()
    {
        InitializeComponent();

        RefreshDate();
    }

    private async void Show_Catalog(object? sender, TappedEventArgs e)
    {
        VariablesData.SelectedProduct = CatalogDataGrid.SelectedItem as Product;

        var editWindow = new ProductEditWindow();
        await editWindow.ShowDialog(GetWindow());

        RefreshDate();
    }

    private void RefreshDate()
    {
        DataContext = App.DbContext;

        if (VariablesData.AuthorizatedUser != null)
        {
            allCatalogProducts = App.DbContext.Products
                .GroupJoin(
                    App.DbContext.Baskets.Where(b => b.IdUser == VariablesData.AuthorizatedUser.IdUser),
                    product => product.IdProduct,
                    basket => basket.IdProduct,
                    (product, baskets) => new
                    {
                        Product = product,
                        Basket = baskets.FirstOrDefault()
                    })

                .Select(x => new CatalogItem
                {
                    ProductId = x.Product.IdProduct,
                    Name = x.Product.Name,
                    Price = x.Product.Price,
                    Provider = x.Product.Provider,
                    BasketCount = x.Basket != null ? x.Basket.Count : 0
                })
                .ToList();
            
            selectedCatalogProducts = allCatalogProducts;

            CatalogDataGrid.ItemsSource = selectedCatalogProducts;

            GetCount();
            
            ApplyFiltersAndSort();
        }
    }

    private void GetCount()
    {
        var basketItems = App.DbContext.Baskets
            .Include(basketItem => basketItem.IdProductNavigation)
            .Where(b => b.IdUser == VariablesData.AuthorizatedUser.IdUser)
            .ToList();

        decimal summ = 0;
        foreach (var basketItem in basketItems)
        {
            summ += basketItem.IdProductNavigation.Price * basketItem.Count;
        }

        SummTextBlock.Text = "Сумма: " + summ;
    }

    private void DeleteCatalog(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var selectedProduct = button?.DataContext as Product;

        if (selectedProduct == null) return;

        VariablesData.SelectedProduct = selectedProduct;

        App.DbContext.Products.Remove(selectedProduct);
        App.DbContext.SaveChanges();

        RefreshDate();
    }

    private void DecreseProduct(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var catalogItem = button?.DataContext as CatalogItem;

        var selectedBasket = App.DbContext.Baskets
            .FirstOrDefault(x =>
                x.IdUser == VariablesData.AuthorizatedUser.IdUser && x.IdProduct == catalogItem.ProductId);

        if (selectedBasket != null)
        {
            selectedBasket.Count--;

            if (selectedBasket.Count == 0)
            {
                App.DbContext.Remove(selectedBasket);
            }
            else
            {
                App.DbContext.Update(selectedBasket);
            }
        }

        App.DbContext.SaveChanges();

        RefreshDate();
    }

    private void AddProduct(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var catalogItem = button?.DataContext as CatalogItem;

        var selectedBasket = App.DbContext.Baskets
            .FirstOrDefault(x =>
                x.IdUser == VariablesData.AuthorizatedUser.IdUser && x.IdProduct == catalogItem.ProductId);

        if (selectedBasket == null)
        {
            // basket not created
            selectedBasket = new Basket
            {
                IdUser = VariablesData.AuthorizatedUser.IdUser,
                IdProduct = catalogItem.ProductId,
                Count = 1
            };

            App.DbContext.Baskets.Add(selectedBasket);
        }
        else
        {
            selectedBasket.Count++;

            App.DbContext.Update(selectedBasket);
        }

        App.DbContext.SaveChanges();

        RefreshDate();
    }

    private void CreateOrder(object? sender, RoutedEventArgs e)
    {
        var basketItems = App.DbContext.Baskets
            .Where(b => b.IdUser == VariablesData.AuthorizatedUser.IdUser)
            .ToList();

        if (basketItems == null) return;

        var newOrder = new ShopOrder()
        {
            IsPaid = false,
            IsDelivered = false,
            IdUser = VariablesData.AuthorizatedUser.IdUser,
        };

        App.DbContext.ShopOrders.Add(newOrder);

        App.DbContext.SaveChanges();

        foreach (var item in basketItems)
        {
            var orderListItem = new OrderItem()
            {
                IdOrder = newOrder.IdOrder,
                IdProduct = item.IdProduct
            };

            App.DbContext.OrderItems.Add(orderListItem);
        }

        App.DbContext.Baskets.RemoveRange(basketItems);

        App.DbContext.SaveChanges();
        RefreshDate();
    }

    private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
    {
        ApplyFiltersAndSort();
    }
}

