using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Core.ViewModels;
using System.Windows.Controls;

namespace DNS_Practice_App.Views.Pages;

public partial class ProductStoragePage : Page, IPage<ProductsStorageViewModel>
{
    public ProductStoragePage (ProductsStorageViewModel viewModel)
    {
        ViewModel = viewModel;
    }

    public ProductsStorageViewModel ViewModel { get; private init; }

    public void Display ()
    {
        DataContext = ViewModel;

        ViewModel.Initialize();

        InitializeComponent();
    }
}