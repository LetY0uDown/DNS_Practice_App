using DNS_Practice_App.Core.ViewModels;
using System.Windows.Controls;

namespace DNS_Practice_App.Views.Pages;

public partial class CitiesPage : Page
{
    public CitiesPage ()
    {
        InitializeComponent();
        DataContext = new CitiesViewModel();
    }
}