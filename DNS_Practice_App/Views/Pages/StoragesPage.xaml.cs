using DNS_Practice_App.Core.ViewModels;
using System.Windows.Controls;

namespace DNS_Practice_App.Views.Pages;

public partial class StoragesPage : Page
{
    public StoragesPage ()
    {
        InitializeComponent();
        DataContext = new StoragesViewModel();
    }
}