using Database;
using Database.Models;
using DNS_Practice_App.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class ProductsReservesViewModel : ViewModel
{
    private List<IEnumerable<ProductReserve>> _prodsOrig;

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

    public List<IEnumerable<ProductReserve>> Products { get; set; }

    public override void Initialize ()
    {
        _prodsOrig = _repository.GetData().ToList();
        Products = _prodsOrig;
    }

    private void Search ()
    {
        if (string.IsNullOrWhiteSpace(SearchText)) {
            Products = _prodsOrig;
            UpdateUI();
            return;
        }

        for (int i = 0;  i < _prodsOrig.Count; i++) {
            Products[i] = _repository.FilterList(_prodsOrig[i], SearchText);
        }

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Products));
    }
}