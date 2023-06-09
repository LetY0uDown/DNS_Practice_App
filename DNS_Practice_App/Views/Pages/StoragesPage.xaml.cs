﻿using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Core.ViewModels;
using System.Windows.Controls;

namespace DNS_Practice_App.Views.Pages;

public partial class StoragesPage : Page, IPage<StoragesViewModel>
{
    public StoragesPage (StoragesViewModel viewModel)
    {
        ViewModel = viewModel;
    }

    public StoragesViewModel ViewModel { get; private init; }

    public void Display ()
    {
        DataContext = ViewModel;

        ViewModel.Initialize();

        InitializeComponent();
    }
}