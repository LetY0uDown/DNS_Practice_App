using DNS_Practice_App.Core.ViewModels;
using System.Windows.Controls;

namespace DNS_Practice_App.Views.Pages;

public partial class ProductsReservesPage : Page
{
    public ProductsReservesPage ()
    {
        InitializeComponent();
        DataContext = new ProductsReservesViewModel();
    }
}