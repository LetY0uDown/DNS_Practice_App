﻿using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Core.ViewModels;
using System.Windows.Controls;

namespace DNS_Practice_App.Views.Pages;

public partial class ProductsPage : Page, IPage<ProductsViewModel>
{
    public ProductsPage (ProductsViewModel viewModel)
    {
        ViewModel = viewModel;
    }

    public ProductsViewModel ViewModel { get; private init; }

    public void Display ()
    {
        DataContext = ViewModel;

        ViewModel.Initialize();

        InitializeComponent();
    }
}