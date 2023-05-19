using DNS_Practice_App.Core.ViewModels;
using System.Windows;

namespace DNS_Practice_App.Views;

public partial class ApplicationWindow : Window
{
    public ApplicationWindow ()
    {
        InitializeComponent();

        DataContext = new LoginNavigationViewModel();
    }
}
