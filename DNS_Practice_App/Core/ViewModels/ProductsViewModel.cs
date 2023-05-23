using Database;
using Database.Models;
using DNS_Practice_App.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class ProductsViewModel : ViewModel
{
    private List<IEnumerable<Product>> _prodsOrig;

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

    public List<IEnumerable<Product>> Products { get; set; }

    public override void Initialize ()
    {
        _prodsOrig = _repository.GetData().ToList();
        Products = _prodsOrig.ToList();
    }

    private void Search ()
    {
        if (string.IsNullOrEmpty(SearchText)) {
            Products = _prodsOrig.ToList();
        } else {
            for (int i = 0; i < _prodsOrig.Count; i++) {
                Products[i] = _repository.FilterList(_prodsOrig[i], SearchText);
            }
        }

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Products));
    }
}