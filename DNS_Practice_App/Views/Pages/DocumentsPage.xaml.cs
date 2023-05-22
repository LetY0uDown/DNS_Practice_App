using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Core.ViewModels;
using System.Windows.Controls;

namespace DNS_Practice_App.Views.Pages;

public partial class DocumentsPage : Page, IPage<DocumentsViewModel>
{
    public DocumentsPage (DocumentsViewModel viewModel)
    {
        ViewModel = viewModel;
    }

    public DocumentsViewModel ViewModel  { get; private init; }

    public void Display ()
    {
        DataContext = ViewModel;

        ViewModel.Initialize();

        InitializeComponent();
    }
}