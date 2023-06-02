using Database;
using Database.Connections;
using Database.Models;
using DNS_Practice_App.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class ProductsStorageViewModel : ViewModel
{
    private List<ProductStorage> _listOrig;

    private readonly IFilter<ProductStorage> _filter;
    private readonly IMySqlDatabase _mySqlDatabase;
    private string _searchText;

    public ProductsStorageViewModel (IFilter<ProductStorage> filter, IMySqlDatabase mySqlDatabase)
    {
        _filter = filter;
        _mySqlDatabase = mySqlDatabase;
        UpdateList = new(o => {
            Initialize();
            UpdateUI();
        });
    }

    public string SearchText
    {
        get => _searchText;
        set {
            _searchText = value;
            Search();
        }
    }

    public UICommand UpdateList { get; private init; }

    public List<ProductStorage> Products { get; set; }

    public override void Initialize ()
    {
        _listOrig = _mySqlDatabase.Get<ProductStorage>().ToList();
        Products = _listOrig;
    }

    private void Search ()
    {
        if (string.IsNullOrWhiteSpace(SearchText)) {
            Products = _listOrig;
            UpdateUI();
            return;
        }

        Products = _filter.FilterList(_listOrig, SearchText).ToList();

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Products));
    }
}