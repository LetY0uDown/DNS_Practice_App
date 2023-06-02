using Database;
using Database.Connections;
using Database.Models;
using DNS_Practice_App.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class CitiesViewModel : ViewModel
{
    private List<City> _citiesOrig;

    private readonly IFilter<City> _filter;
    private readonly IMySqlDatabase _mySqlDatabase;
    private string _searchString;

    public CitiesViewModel (IFilter<City> filter, IMySqlDatabase mySqlDatabase)
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

    public List<City> Cities { get; set; }

    public override void Initialize ()
    {
        _citiesOrig = _mySqlDatabase.Get<City>().ToList();
        Cities = _citiesOrig;
    }

    private void Search ()
    {
        if (string.IsNullOrEmpty(SearchText))
        {
            Cities = _citiesOrig.ToList();
        }
        else
        {
            Cities = _filter.FilterList(_citiesOrig, SearchText).ToList();
        }

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Cities));
    }
}