using Database;
using Database.Connections;
using Database.Models;
using DNS_Practice_App.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class ProductsViewModel : ViewModel
{
    private List<Product> _prodsOrig;

    private readonly IFilter<Product> _filter;
    private readonly IMySqlDatabase _mySqlDatabase;
    private string _searchString;

    public ProductsViewModel (IFilter<Product> filter, IMySqlDatabase mySqlDatabase)
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
        get => _searchString;
        set {
            _searchString = value;
            Search();
        }
    }

    public UICommand UpdateList { get; private init; }

    public List<Product> Products { get; set; }

    public override void Initialize ()
    {
        _prodsOrig = _mySqlDatabase.Get<Product>().ToList();
        Products = _prodsOrig.ToList();
    }

    private void Search ()
    {
        if (string.IsNullOrEmpty(SearchText)) {
            Products = _prodsOrig.ToList();
        } else {
            Products = _filter.FilterList(_prodsOrig, SearchText).ToList();
        }

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Products));
    }
}