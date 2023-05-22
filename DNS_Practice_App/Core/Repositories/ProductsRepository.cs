using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.Repositories;

internal class ProductsRepository : IRepository<Product>
{
    public IEnumerable<Product> GetFromFirstDB ()
    {
        using DNS_practiceContext_One context = new();

        return context.Products.ToList();
    }

    public IEnumerable<Product> GetFromSecondDB ()
    {
        using DNS_practiceContext_Two context = new();

        return context.Products.ToList();
    }

    public IEnumerable<Product> SearchFrom (IEnumerable<Product> source, string query)
    {
        return source.Where(e => e.Name.ToLower().Contains(query.ToLower()) || e.Id.ToString().Contains(query));
    }
}