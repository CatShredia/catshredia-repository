using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace ApplicationShop.Windows;

public partial class OrderShowWindow : Window
{
    public OrderShowWindow()
    {
        InitializeComponent();
        
        RefreshData();
    }

    public void RefreshData()
    {
        OrderListDataGrid.ItemsSource = App.DbContext.OrderLists
            .Where(list => list.IdOrderNavigation.IdUser == VariablesData.AuthorizatedUser.IdUser)
            .ToList();
    }
}