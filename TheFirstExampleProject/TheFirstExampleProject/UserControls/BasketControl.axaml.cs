using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TheFirstExampleProject.Data;
using TheFirstExampleProject.ViewModels;

namespace TheFirstExampleProject.UserControls;

public partial class BasketControl : UserControl
{
    public BasketControl()
    {
        InitializeComponent();

        DataContext = new Basket();
        
        ComboBoxItemUser.ItemsSource = App.DbContext.Users;
        ComboBoxItemItem.ItemsSource = App.DbContext.Items;
        BasketDataGrid.ItemsSource = App.DbContext.Baskets.ToList();
    }
    
    
    private void Create_Basket(object? sender, RoutedEventArgs e)
    {
        BasketMessageBox.Text = null;
        Console.WriteLine("Create basket");
        
        var selectedUser = ComboBoxItemUser.SelectedValue as User;
        var selectedItem = ComboBoxItemItem.SelectedValue as Item;
        
        if
        (
            selectedUser == null ||
            selectedItem == null
        )
        {
            return;
        }

        
        bool rule = App.DbContext.Baskets
            .Any(b => b.IdUser == selectedUser.IdUser && b.IdItem == selectedItem.IdItem);

        if (!rule)
        {

            var newBasket = new Basket()
            {
                IdUser = selectedUser.IdUser,
                IdItem = selectedItem.IdItem,
                Count = int.Parse(BasketCount.Text),
            };

            App.DbContext.Baskets.Add(newBasket);
        }
        else
        {
            var selectedBasket = App.DbContext.Baskets
                .FirstOrDefault(b => 
                    b.IdUser == selectedUser.IdUser && 
                    b.IdItem == selectedItem.IdItem);

            selectedBasket.Count = BasketCount == null ? 0 : Convert.ToInt32(BasketCount.Text);
        }

        App.DbContext.SaveChanges();

        ComboBoxItemUser.ItemsSource = App.DbContext.Users;
        ComboBoxItemItem.ItemsSource = App.DbContext.Items;
        BasketDataGrid.ItemsSource = App.DbContext.Baskets.ToList();
        
    }

    private void Button_Basket_Delete_OnClick(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var selectedBasket = button?.DataContext as Basket;

        Console.WriteLine((selectedBasket == null) ? "Basket not found" : "Basket founded");

        if (selectedBasket == null) return;

        App.DbContext.Baskets.Remove(selectedBasket);
        App.DbContext.SaveChanges();

        ComboBoxItemUser.ItemsSource = App.DbContext.Users;
        ComboBoxItemItem.ItemsSource = App.DbContext.Items;
        BasketDataGrid.ItemsSource = App.DbContext.Baskets.ToList();
    }
}