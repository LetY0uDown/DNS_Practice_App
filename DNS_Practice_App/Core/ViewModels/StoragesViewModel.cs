using Database;
using Database.Models;
using DNS_Practice_App.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class StoragesViewModel : ViewModel
{
    private List<IEnumerable<Storage>> _storagesOrig;
    private readonly IRepository<Storage> _repository;
    private string _searchString;

    public StoragesViewModel (IRepository<Storage> repository)
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

    public List<IEnumerable<Storage>> Storages { get; set; }

    public override void Initialize ()
    {
        _storagesOrig = _repository.GetData().ToList();
        Storages = _storagesOrig;
    }

    private void Search ()
    {
        if (string.IsNullOrEmpty(SearchText)) {
            Storages = _storagesOrig;
            UpdateUI();
            return;
        }

        for (int i = 0; i < Storages.Count; i++) {
            Storages[i] = _repository.FilterList(_storagesOrig[i], SearchText);
        }

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Storages));
    }
}