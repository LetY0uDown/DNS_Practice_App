using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.Repositories;

internal class ProductStorageRepository : IRepository<ProductStorage>
{
    public IEnumerable<ProductStorage> GetFromFirstDB ()
    {
        using DNS_practiceContext_One context = new();

        return context.ProductStorages.Include(e => e.Product).Include(e => e.Document).OrderBy(e => e.Product.Name).ToList();
    }

    public IEnumerable<ProductStorage> GetFromSecondDB ()
    {
        using DNS_practiceContext_Two context = new();

        return context.ProductStorages.Include(e => e.Product).Include(e => e.Document).OrderBy(e => e.Product.Name).ToList();
    }
}