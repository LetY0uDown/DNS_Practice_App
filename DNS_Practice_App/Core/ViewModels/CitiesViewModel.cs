using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class CitiesViewModel : ViewModel
{
    private IEnumerable<City> _cities1Orig;
    private IEnumerable<City> _cities2Orig;

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

    public List<City> Cities_1 { get; set; }
    public List<City> Cities_2 { get; set; }

    public string FirstDB => App.FirstConnection.Database;
    public string SecondDB => App.SecondConnection.Database;

    public override void Initialize ()
    {
        _cities1Orig = _repository.GetFromFirstDB();
        _cities2Orig = _repository.GetFromSecondDB();

        Cities_1 = _cities1Orig.ToList();
        Cities_2 = _cities2Orig.ToList();
    }

    private void Search ()
    {
        if (string.IsNullOrEmpty(SearchText)) {
            Cities_1 = _cities1Orig.ToList();
            Cities_2 = _cities2Orig.ToList();
        } else {
            Cities_1 = _repository.SearchFrom(_cities1Orig, SearchText).ToList();
            Cities_2 = _repository.SearchFrom(_cities2Orig, SearchText).ToList();
        }

        UpdateUI();
    }

    private void UpdateUI ()
    {
        OnPropertyChanged(nameof(Cities_1));
        OnPropertyChanged(nameof(Cities_2));
    }
}