using Database;
using Database.Models;
using DNS_Practice_App.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class ProductsStorageViewModel : ViewModel
{
    private List<IEnumerable<ProductStorage>> _listOrig;

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

    public List<IEnumerable<ProductStorage>> Products { get; set; }

    public override void Initialize ()
    {
        _listOrig = _repository.GetData().ToList();
        Products = _listOrig;
    }

    private void Search ()
    {
        if (string.IsNullOrWhiteSpace(SearchText)) {
            Products = _listOrig;
            UpdateUI();
            return;
        }

        for (int i = 0; i < Products.Count; i++) {
            Products[i] = _repository.FilterList(_listOrig[i], SearchText);
        }

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Products));
    }
}