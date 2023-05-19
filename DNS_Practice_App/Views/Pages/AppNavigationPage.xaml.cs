using DNS_Practice_App.Core.ViewModels;
using System.Windows.Controls;

namespace DNS_Practice_App.Views.Pages;

public partial class AppNavigationPage : Page
{
    public AppNavigationPage ()
    {
        InitializeComponent();

        DataContext = new AppNavigationViewModel();
    }
}