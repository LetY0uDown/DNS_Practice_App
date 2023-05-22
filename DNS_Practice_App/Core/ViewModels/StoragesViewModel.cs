using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class StoragesViewModel : ViewModel
{
    private string _searchString;

    public StoragesViewModel ()
    {
        using (var context = new DNS_practiceContext_One()) {
            Storages_1 = context.Storages.ToList();

            using (var context2 = new DNS_practiceContext_Two()) {
                Storages_2 = context2.Storages.ToList();
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
                    Storages_1 = context.Storages.ToList();

                    using (var context2 = new DNS_practiceContext_Two()) {
                        Storages_2 = context2.Storages.ToList();
                    }
                }
            }

            Storages_1 = Storages_1.Where(e => e.Name.ToLower().Contains(value.ToLower()) || e.City.Name.ToLower().Contains(value.ToLower())).ToList();
            Storages_2 = Storages_2.Where(e => e.Name.ToLower().Contains(value.ToLower()) || e.City.Name.ToLower().Contains(value.ToLower())).ToList();

            OnPropertyChanged(nameof(Storages_1));
            OnPropertyChanged(nameof(Storages_2));
        }
    }

    public List<Storage> Storages_1 { get; set; }
    public List<Storage> Storages_2 { get; set; }

    public string FirstDB => App.FirstConnection.Database;
    public string SecondDB => App.SecondConnection.Database;
}