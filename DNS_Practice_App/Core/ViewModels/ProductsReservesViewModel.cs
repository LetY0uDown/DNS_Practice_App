using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class ProductsReservesViewModel : ViewModel
{
    private IEnumerable<ProductReserve> _prods1Orig;
    private IEnumerable<ProductReserve> _prods2Orig;

    private readonly IRepository<ProductReserve> _repository;
    private string _searchText;

    public ProductsReservesViewModel (IRepository<ProductReserve> repository)
    {
        _repository = repository;

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

    public List<ProductReserve> Products_FirstDB { get; set; }
    public List<ProductReserve> Products_SecondDB { get; set; }

    public string FirstDB => App.FirstConnection.Database;
    public string SecondDB => App.SecondConnection.Database;

    public override void Initialize ()
    {
        _prods1Orig = _repository.GetFromFirstDB();
        _prods2Orig = _repository.GetFromSecondDB();

        Products_FirstDB = _prods1Orig.ToList();
        Products_SecondDB = _prods2Orig.ToList();
    }

    private void Search ()
    {
        if (string.IsNullOrWhiteSpace(SearchText)) {
            Products_FirstDB = _prods1Orig.ToList();
            Products_SecondDB = _prods2Orig.ToList();

            UpdateUI();

            return;
        }

        Products_FirstDB = _repository.SearchFrom(_prods1Orig, SearchText).ToList();
        Products_SecondDB = _repository.SearchFrom(_prods2Orig, SearchText).ToList();

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Products_FirstDB));
        OnPropertyChanged(nameof(Products_SecondDB));
    }
}