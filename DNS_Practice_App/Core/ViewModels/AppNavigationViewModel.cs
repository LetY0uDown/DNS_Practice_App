using DNS_Practice_App.Core.Base;
using DNS_Practice_App.Views.Pages;
using System.Threading.Tasks;

namespace DNS_Practice_App.Core.ViewModels;

public class AppNavigationViewModel : NavigationalViewModel
{
    public AppNavigationViewModel ()
    {
        // костыль
        Task.Run(async () => {
            await Task.Delay(1000);

            Navigation.NavigationModel = this;
            App.Current.Dispatcher.Invoke(Navigation.DisplayPage<ProductsReservesPage>);
        });

        DisplayReservesCommand = new(o => {
            Navigation.DisplayPage<ProductsReservesPage>();
        });

        DisplayProductsOnStoragesCommand = new(o => {
            Navigation.DisplayPage<ProductStoragePage>();
        });

        DisplayProductsCommand = new(o => {
            Navigation.DisplayPage<ProductsPage>();
        });

        DisplayDocumentsCommand = new(o => {
            Navigation.DisplayPage<DocumentsPage>();
        });

        DisplayCitiesCommand = new(o => {
            Navigation.DisplayPage<CitiesPage>();
        });

        DisplayStoragesCommand = new(o => {
            Navigation.DisplayPage<StoragesPage>();
        });
    }

    public UICommand DisplayReservesCommand { get; private init; }
    public UICommand DisplayProductsOnStoragesCommand { get; private init; }
    public UICommand DisplayProductsCommand { get; private init; }
    public UICommand DisplayDocumentsCommand { get; private init; }
    public UICommand DisplayCitiesCommand { get; private init; }
    public UICommand DisplayStoragesCommand { get; private init; }
}