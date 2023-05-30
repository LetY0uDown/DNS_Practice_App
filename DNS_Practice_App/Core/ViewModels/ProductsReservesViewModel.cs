using Database;
using Database.Connections;
using Database.Models;
using DNS_Practice_App.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class ProductsReservesViewModel : ViewModel
{
    private List<ProductReserve> _prodsOrig;

    private readonly IFilter<ProductReserve> _filter;
    private readonly MySqlDatabase _mySqlDatabase;
    private string _searchText;

    public ProductsReservesViewModel (IFilter<ProductReserve> filter, MySqlDatabase mySqlDatabase)
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

    public List<ProductReserve> Products { get; set; }

    public override void Initialize ()
    {
        _prodsOrig = _mySqlDatabase.Get<ProductReserve>().ToList();
        Products = _prodsOrig;
    }

    private void Search ()
    {
        if (string.IsNullOrWhiteSpace(SearchText)) {
            Products = _prodsOrig;
            UpdateUI();
            return;
        }

        Products = _filter.FilterList(_prodsOrig, SearchText).ToList();

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Products));
    }
}