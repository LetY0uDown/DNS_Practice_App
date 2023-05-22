using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class ProductsViewModel : ViewModel
{
    private IEnumerable<Product> _prods1Orig;
    private IEnumerable<Product> _prods2Orig;

    private readonly IRepository<Product> _repository;
    private string _searchString;

    public ProductsViewModel (IRepository<Product> repository)
    {
        _repository = repository;

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

    public List<Product> Products_1 { get; set; }
    public List<Product> Products_2 { get; set; }

    public string FirstDB => App.FirstConnection.Database;
    public string SecondDB => App.SecondConnection.Database;

    public override void Initialize ()
    {
        _prods1Orig = _repository.GetFromFirstDB();
        _prods2Orig = _repository.GetFromSecondDB();

        Products_1 = _prods1Orig.ToList();
        Products_2= _prods2Orig.ToList();
    }

    private void Search ()
    {
        if (string.IsNullOrEmpty(SearchText)) {
            Products_1 = _prods1Orig.ToList ();
            Products_2 = _prods2Orig.ToList ();
        } else {
            Products_1 = _repository.SearchFrom(_prods1Orig, SearchText).ToList();
            Products_2 = _repository.SearchFrom(_prods2Orig, SearchText).ToList();
        }

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Products_1));
        OnPropertyChanged(nameof(Products_2));
    }
}