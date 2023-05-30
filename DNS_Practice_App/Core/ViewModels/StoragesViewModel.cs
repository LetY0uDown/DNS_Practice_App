using Database;
using Database.Connections;
using Database.Models;
using DNS_Practice_App.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class StoragesViewModel : ViewModel
{
    private List<Storage> _storagesOrig;
    private readonly IFilter<Storage> _filter;
    private readonly MySqlDatabase _mySqlDatabase;
    private string _searchString;

    public StoragesViewModel (IFilter<Storage> filter, MySqlDatabase mySqlDatabase)
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

    public List<Storage> Storages { get; set; }

    public override void Initialize ()
    {
        _storagesOrig = _mySqlDatabase.Get<Storage>().ToList();
        Storages = _storagesOrig;
    }

    private void Search ()
    {
        if (string.IsNullOrEmpty(SearchText)) {
            Storages = _storagesOrig;
            UpdateUI();
            return;
        }

        Storages = _filter.FilterList(_storagesOrig, SearchText).ToList();

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Storages));
    }
}