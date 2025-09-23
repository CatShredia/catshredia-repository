using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using TheFirstExampleProject.Data;
using TheFirstExampleProject.Models;
using TheFirstExampleProject.ViewModels;
using TheFirstExampleProject.Views.EditViews;

namespace TheFirstExampleProject.UserControls;

public partial class ItemsControl : UserControl
{
    public ItemsControl()
    {
        InitializeComponent();
        
        RefreshData();
    }
    
    private Window? GetWindow()
    {
        return this.GetVisualRoot() as Window;
    }
    
    private async void Show_Item(object? sender, TappedEventArgs e)
    {
        var selectedItem = ItemDataGrid.SelectedItem as Item;
        Console.WriteLine("Item need " + selectedItem.IdItem);
        UserVariableData.selectedItem = selectedItem;

        var itemEditWindow = new ItemEditWindow();
        await itemEditWindow.ShowDialog(GetWindow());

        RefreshData();
    }

    private async void Create_Item_Button(object? sender, RoutedEventArgs e)
    {
        UserVariableData.selectedItem = null;

        var itemEditWindow = new ItemEditWindow();
        await itemEditWindow.ShowDialog(GetWindow());

        RefreshData();
    }

    private void RefreshData()
    {
        ItemDataGrid.ItemsSource = App.DbContext.Items.ToList();
    }
}