using DNS_Practice_App.Core.Base;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class ProductsViewModel : ViewModel
{
    private string _searchString;

    public ProductsViewModel ()
    {
        using (var context = new DNS_practiceContext_One()) {
            Products_1 = context.Products.ToList();

            using (var context2 = new DNS_practiceContext_Two()) {
                Products_2 = context2.Products.ToList();
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
                    Products_1 = context.Products.ToList();

                    using (var context2 = new DNS_practiceContext_Two()) {
                        Products_2 = context2.Products.ToList();
                    }
                }
            }

            Products_1 = Products_1.Where(e => e.Name.ToLower().Contains(value.ToLower()) || e.Id.ToString().Contains(value)).ToList();
            Products_2 = Products_2.Where(e => e.Name.ToLower().Contains(value.ToLower()) || e.Id.ToString().Contains(value)).ToList();

            OnPropertyChanged(nameof(Products_1));
            OnPropertyChanged(nameof(Products_2));
        }
    }

    public List<Product> Products_1 { get; set; }
    public List<Product> Products_2 { get; set; }

    public string FirstDB => App.FirstConnection.Database;
    public string SecondDB => App.SecondConnection.Database;
}