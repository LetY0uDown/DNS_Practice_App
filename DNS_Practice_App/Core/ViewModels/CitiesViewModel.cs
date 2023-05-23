using Database;
using Database.Models;
using DNS_Practice_App.Abstracts;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class CitiesViewModel : ViewModel
{
    private List<IEnumerable<City>> _citiesOrig;

    private readonly IRepository<City> _repository;
    private string _searchString;

    public CitiesViewModel (IRepository<City> repository)
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

    public List<IEnumerable<City>> Cities { get; set; }

    public override void Initialize ()
    {
        _citiesOrig = _repository.GetData().ToList();
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
            for (int i = 0; i < Cities.Count; i++)
            {
                Cities[i] = _repository.FilterList(_citiesOrig[i], SearchText);
            }
        }

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Cities));
    }
}