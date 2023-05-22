using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Core.ViewModels;
using System.Windows.Controls;

namespace DNS_Practice_App.Views.Pages;

public partial class LoginPage : Page, IPage<LoginPageViewModel>
{
    public LoginPage (LoginPageViewModel viewModel)
    {
        ViewModel = viewModel;
    }

    public LoginPageViewModel ViewModel { get; private init; }

    public void Display ()
    {
        DataContext = ViewModel;

        ViewModel.Initialize();

        InitializeComponent();
    }
}
