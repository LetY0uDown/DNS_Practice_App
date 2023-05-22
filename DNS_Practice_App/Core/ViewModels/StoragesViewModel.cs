using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class StoragesViewModel : ViewModel
{
    private IEnumerable<Storage> _storages1Orig;
    private IEnumerable<Storage> _storages2Orig;

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

    public List<Storage> Storages_1 { get; set; }
    public List<Storage> Storages_2 { get; set; }

    public string FirstDB => App.FirstConnection.Database;
    public string SecondDB => App.SecondConnection.Database;

    public override void Initialize ()
    {
        _storages1Orig = _repository.GetFromFirstDB();
        _storages2Orig = _repository.GetFromSecondDB();

        Storages_1 = _storages1Orig.ToList();
        Storages_2 = _storages2Orig.ToList();
    }

    private void Search ()
    {
        if (string.IsNullOrEmpty(SearchText)) {
            Storages_1 = _storages1Orig.ToList();
            Storages_2 = _storages2Orig.ToList();
        }

        Storages_1 = _repository.SearchFrom(_storages1Orig, SearchText).ToList();
        Storages_2 = _repository.SearchFrom(_storages2Orig, SearchText).ToList();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Storages_1));
        OnPropertyChanged(nameof(Storages_2));
    }
}