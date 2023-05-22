using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Core.ViewModels;
using System.Windows.Controls;

namespace DNS_Practice_App.Views.Pages;

public partial class ProductsReservesPage : Page, IPage<ProductsReservesViewModel>
{
    public ProductsReservesPage (ProductsReservesViewModel viewModel)
    {
        ViewModel = viewModel;
    }

    public ProductsReservesViewModel ViewModel { get; private init; }

    public void Display ()
    {
        DataContext = ViewModel;

        ViewModel.Initialize();

        InitializeComponent();
    }
}