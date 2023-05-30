﻿using Database;
using Database.Models;
using Database.Repositories;
using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Core.ViewModels;
using DNS_Practice_App.Views.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace DNS_Practice_App.Core.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static void AddFilters (this IServiceCollection services)
    {
        services.AddSingleton<IFilter<Product>, ProductsFilter>();
        services.AddSingleton<IFilter<Storage>, StorageFilter>();
        services.AddSingleton<IFilter<ProductReserve>, ProductReservesFilter>();
        services.AddSingleton<IFilter<ProductStorage>, ProductStorageFilter>();
        services.AddSingleton<IFilter<City>, CitiesFilter>();
        services.AddSingleton<IFilter<Document>, DocumentsFilter>();
    }

    internal static void AddPages (this IServiceCollection services)
    {
        services.AddSingleton<IPage<CitiesViewModel>, CitiesPage>();
        services.AddSingleton<IPage<DocumentsViewModel>, DocumentsPage>();
        services.AddSingleton<IPage<ProductsViewModel>, ProductsPage>();
        services.AddSingleton<IPage<ProductsReservesViewModel>, ProductsReservesPage>();
        services.AddSingleton<IPage<ProductsStorageViewModel>, ProductStoragePage>();
        services.AddSingleton<IPage<StoragesViewModel>, StoragesPage>();
    }

    internal static void AddViewModels (this IServiceCollection services)
    {
        services.AddSingleton<AppNavigationViewModel>();
        services.AddSingleton<CitiesViewModel>();
        services.AddSingleton<DocumentsViewModel>();
        services.AddSingleton<ProductsReservesViewModel>();
        services.AddSingleton<ProductsStorageViewModel>();
        services.AddSingleton<ProductsViewModel>();
        services.AddSingleton<StoragesViewModel>();
    }
}