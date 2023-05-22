using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class ProductsStorageViewModel : ViewModel
{
    private IEnumerable<ProductStorage> _list1Orig;
    private IEnumerable<ProductStorage> _list2Orig;

    private readonly IRepository<ProductStorage> _repository;
    private string _searchText;

    public ProductsStorageViewModel (IRepository<ProductStorage> repository)
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

    public List<ProductStorage> Products_FirstDB { get; set; }
    public List<ProductStorage> Products_SecondDB { get; set; }

    public string FirstDB => App.FirstConnection.Database;
    public string SecondDB => App.SecondConnection.Database;

    public override void Initialize ()
    {
        _list1Orig = _repository.GetFromFirstDB();
        _list2Orig = _repository.GetFromSecondDB();

        Products_FirstDB = _list1Orig.ToList();
        Products_SecondDB = _list2Orig.ToList();
    }

    private void Search ()
    {
        if (string.IsNullOrWhiteSpace(SearchText)) {
            Products_FirstDB = _list1Orig.ToList();
            Products_SecondDB = _list2Orig.ToList();

            UpdateUI();

            return;
        }

        Products_FirstDB = _list1Orig.Where(entity =>
                entity.DocumentId.ToString().Contains(SearchText) ||
                entity.ProductId.ToString().Contains(SearchText) ||
                entity.Product.Name.ToLower().Contains(SearchText.ToLower()) ||
                entity.Document.Name.ToLower().Contains(SearchText.ToLower()))
            .ToList();

        Products_SecondDB = _list2Orig.Where(entity =>
                entity.DocumentId.ToString().Contains(SearchText) ||
                entity.ProductId.ToString().Contains(SearchText) ||
                entity.Product.Name.ToLower().Contains(SearchText.ToLower()) ||
                entity.Document.Name.ToLower().Contains(SearchText.ToLower()))
            .ToList();

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Products_FirstDB));
        OnPropertyChanged(nameof(Products_SecondDB));
    }
}