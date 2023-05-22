using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Core.ViewModels;
using System.Windows.Controls;

namespace DNS_Practice_App.Views.Pages;

public partial class CitiesPage : Page, IPage<CitiesViewModel>
{
    public CitiesPage (CitiesViewModel viewModel)
    {
        ViewModel = viewModel;
    }

    public CitiesViewModel ViewModel { get; private init; }

    public void Display ()
    {
        DataContext = ViewModel;

        ViewModel.Initialize();

        InitializeComponent();
    }
}