using DNS_Practice_App.Core.Base;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class CitiesViewModel : ViewModel
{
    private string _searchString;

    public CitiesViewModel ()
    {
        using (var context = new DNS_practiceContext_One()) {
            Cities_1 = context.Cities.ToList();

            using (var context2 = new DNS_practiceContext_Two()) {
                Cities_2 = context2.Cities.ToList();
            }
        }
    }

    public string SearchText
    {
        get => _searchString;
        set {
            _searchString = value;

            if (string.IsNullOrEmpty(value)) {
                using (var context = new DNS_practiceContext_One()) {
                    Cities_1 = context.Cities.ToList();

                    using (var context2 = new DNS_practiceContext_Two()) {
                        Cities_2 = context2.Cities.ToList();
                    }
                }
            }

            Cities_1 = Cities_1.Where(city => city.Name.ToLower().Contains(value.ToLower())).ToList();
            Cities_2 = Cities_2.Where(city => city.Name.ToLower().Contains(value.ToLower())).ToList();

            OnPropertyChanged(nameof(Cities_1));
            OnPropertyChanged(nameof(Cities_2));
        }
    }

    public List<City> Cities_1 { get; set; }
    public List<City> Cities_2 { get; set; }

    public string FirstDB => App.FirstConnection.Database;
    public string SecondDB => App.SecondConnection.Database;
}