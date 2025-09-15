using System;
using System.Collections.ObjectModel;
using System.Linq;
using TheFirstExampleProject.Data;

namespace TheFirstExampleProject.ViewModels;

public class BasketWindowViewModel : ViewModelBase
{
    public ObservableCollection<Basket> Baskets { get; set; }
    
    public BasketWindowViewModel()
    {
        RefreshData();
    }
    
    public void RefreshData()
    {
        Baskets = new ObservableCollection<Basket>(App.DbContext.Baskets.ToList());
        OnPropertyChanged(nameof(Basket));
        Console.WriteLine(Baskets.Count + " basket from database");
    }
}