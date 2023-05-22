using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Core.Repositories;
using DNS_Practice_App.Core.ViewModels;
using DNS_Practice_App.Models;
using DNS_Practice_App.Views.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace DNS_Practice_App.Core.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static void AddRepositorties(this IServiceCollection services)
    {
        services.AddSingleton<IRepository<Product>, ProductsRepository>();
        services.AddSingleton<IRepository<Storage>, StorageRepository>();
        services.AddSingleton<IRepository<ProductReserve>, ProductReservesRepository>();
        services.AddSingleton<IRepository<ProductStorage>, ProductStorageRepository>();
        services.AddSingleton<IRepository<City>, CitiesRepository>();
        services.AddSingleton<IRepository<Document>, DocumentsRepository>();
    }

    internal static void AddPages(this IServiceCollection services)
    {
        services.AddSingleton<IPage<CitiesViewModel>, CitiesPage>();
        services.AddSingleton<IPage<DocumentsViewModel>, DocumentsPage>();
        services.AddSingleton<IPage<LoginPageViewModel>, LoginPage>();
        services.AddSingleton<IPage<ProductsViewModel>, ProductsPage>();
        services.AddSingleton<IPage<ProductsReservesViewModel>, ProductsReservesPage>();
        services.AddSingleton<IPage<ProductsStorageViewModel>, ProductStoragePage>();
        services.AddSingleton<IPage<StoragesViewModel>, StoragesPage>();
    }

    internal static void AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<AppNavigationViewModel>();
        services.AddSingleton<CitiesViewModel>();
        services.AddSingleton<DocumentsViewModel>();
        services.AddSingleton<LoginPageViewModel>();
        services.AddSingleton<ProductsReservesViewModel>();
        services.AddSingleton<ProductsStorageViewModel>();
        services.AddSingleton<ProductsViewModel>();
        services.AddSingleton<StoragesViewModel>();
    }
}