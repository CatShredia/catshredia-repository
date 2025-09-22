using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TheFirstExampleProject.Data;
using TheFirstExampleProject.Models;
using TheFirstExampleProject.ViewModels;

namespace TheFirstExampleProject.Views.EditViews;

public partial class ItemEditWindow : Window
{
    
    public ItemEditWindow()
    {
        InitializeComponent();

        DataContext = UserVariableData.selectedItem;
        
        
        if (UserVariableData.selectedItem != null)
        {
            NameTextBox.Text = UserVariableData.selectedItem.Name;
            PriceTextBox.Text = UserVariableData.selectedItem.Price.ToString();
            DescriptionTextBox.Text = UserVariableData.selectedItem.Description;
        }
    }

    private void Create_Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (UserVariableData.selectedItem != null)
        {
            Console.WriteLine("Item " + UserVariableData.selectedItem.Name);

            var idItem = UserVariableData.selectedItem.IdItem;
            var selectedItem = App.DbContext.Items.FirstOrDefault(x => x.IdItem == idItem);

            if (selectedItem == null) return;

            selectedItem.Name = NameTextBox.Text;
            selectedItem.Price = Convert.ToInt32(PriceTextBox.Text);
            selectedItem.Description = DescriptionTextBox.Text;
        }
        else
        {
            Console.WriteLine("Create new Item");

            var newItem = new Item()
            {
                Name = NameTextBox.Text,
                Price = Convert.ToInt32(PriceTextBox.Text),
                Description = DescriptionTextBox.Text
            };
            App.DbContext.Items.Add(newItem);
        }

        App.DbContext.SaveChanges();
        
        
        Close();
    }
}