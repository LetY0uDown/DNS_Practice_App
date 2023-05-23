using DNS_Practice_App.Abstracts;

namespace DNS_Practice_App.Core.ViewModels;

public class AppNavigationViewModel : NavigationalViewModel
{
    private readonly INavigation _navigation;

    public AppNavigationViewModel (INavigation navigation)
    {
        _navigation = navigation;

        DisplayReservesCommand = new(o => {
            _navigation.DisplayPage<IPage<ProductsReservesViewModel>>();
        });

        DisplayProductsOnStoragesCommand = new(o => {
            _navigation.DisplayPage<IPage<ProductsStorageViewModel>>();
        });

        DisplayProductsCommand = new(o => {
            _navigation.DisplayPage<IPage<ProductsViewModel>>();
        });

        DisplayDocumentsCommand = new(o => {
            _navigation.DisplayPage<IPage<DocumentsViewModel>>();
        });

        DisplayCitiesCommand = new(o => {
            _navigation.DisplayPage<IPage<CitiesViewModel>>();
        });

        DisplayStoragesCommand = new(o => {
            _navigation.DisplayPage<IPage<StoragesViewModel>>();
        });
    }

    public UICommand DisplayDatabasesCommand { get; private init; }
    public UICommand DisplayReservesCommand { get; private init; }
    public UICommand DisplayProductsOnStoragesCommand { get; private init; }
    public UICommand DisplayProductsCommand { get; private init; }
    public UICommand DisplayDocumentsCommand { get; private init; }
    public UICommand DisplayCitiesCommand { get; private init; }
    public UICommand DisplayStoragesCommand { get; private init; }

    public override void Initialize ()
    {
        _navigation.NavigationalModel = this;
        //_navigation.DisplayPage<IPage<LoginPageViewModel>>();
    }
}