using DNS_Practice_App.Core.Base;
using DNS_Practice_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class ProductsStorageViewModel : ViewModel
{
    private string _searchText;

    public ProductsStorageViewModel ()
    {
        using (var context = new DNS_practiceContext_One()) {
            Products_FirstDB = context.ProductStorages.Include(e => e.Product).Include(e => e.Document).OrderBy(e => e.Product.Name).ToList();

            using (var context2 = new DNS_practiceContext_Two()) {
                Products_SecondDB = context2.ProductStorages.Include(e => e.Product).Include(e => e.Document).OrderBy(e => e.Product.Name).ToList();
            }
        }
    }

    public string SearchText
    {
        get => _searchText;
        set {
            _searchText = value;

            if (string.IsNullOrWhiteSpace(value)) {
                using (var context = new DNS_practiceContext_One()) {
                    Products_FirstDB = context.ProductStorages.Include(e => e.Product).Include(e => e.Document).OrderBy(e => e.Product.Name).ToList();

                    using (var context2 = new DNS_practiceContext_Two()) {
                        Products_SecondDB = context2.ProductStorages.Include(e => e.Product).Include(e => e.Document).OrderBy(e => e.Product.Name).ToList();
                    }
                }
            }

            Products_FirstDB = Products_FirstDB.Where(entity =>
                    entity.DocumentId.ToString().Contains(SearchText) ||
                    entity.ProductId.ToString().Contains(SearchText) ||
                    entity.Product.Name.ToLower().Contains(SearchText.ToLower()) ||
                    entity.Document.Name.ToLower().Contains(SearchText.ToLower()))
                .ToList();
            OnPropertyChanged(nameof(Products_FirstDB));

            Products_SecondDB = Products_SecondDB.Where(entity =>
                    entity.DocumentId.ToString().Contains(SearchText) ||
                    entity.ProductId.ToString().Contains(SearchText) ||
                    entity.Product.Name.ToLower().Contains(SearchText.ToLower()) ||
                    entity.Document.Name.ToLower().Contains(SearchText.ToLower()))
                .ToList();
            OnPropertyChanged(nameof(Products_SecondDB));
        }
    }

    public List<ProductStorage> Products_FirstDB { get; set; }
    public List<ProductStorage> Products_SecondDB { get; set; }

    public string FirstDB => App.FirstConnection.Database;
    public string SecondDB => App.SecondConnection.Database;
}