using System;
using System.Collections.ObjectModel;
using System.Linq;
using TheFirstExampleProject.Data;

namespace TheFirstExampleProject.ViewModels;

public class ItemWindowViewModel : ViewModelBase
{
    public ObservableCollection<Item> Items { get; set; }
    
    public ItemWindowViewModel()
    {
        RefreshData();
    }
    
    public void RefreshData()
    {
        Items = new ObservableCollection<Item>(App.DbContext.Items.ToList());
        OnPropertyChanged(nameof(Items));
        Console.WriteLine(Items.Count + " items from database");
    }
}