using DNS_Practice_App.Core.Base;
using DNS_Practice_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.ViewModels;

public sealed class ProductsReservesViewModel : ViewModel
{
    private string _searchText;

    public ProductsReservesViewModel ()
    {
        using (var context = new DNS_practiceContext_One()) {
            Products_FirstDB = context.ProductReserves.Include(e => e.Product).Include(e => e.Document).ToList();

            using (var context2 = new DNS_practiceContext_Two()) {
                Products_SecondDB = context2.ProductReserves.Include(e => e.Product).Include(e => e.Document).ToList();
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
                    Products_FirstDB = context.ProductReserves.Include(e => e.Product).Include(e => e.Document).ToList();

                    using (var context2 = new DNS_practiceContext_Two()) {
                        Products_SecondDB = context2.ProductReserves.Include(e => e.Product).Include(e => e.Document).ToList();
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

    public List<ProductReserve> Products_FirstDB { get; set; }
    public List<ProductReserve> Products_SecondDB { get; set; }

    public string FirstDB => App.FirstConnection.Database;
    public string SecondDB => App.SecondConnection.Database;
}