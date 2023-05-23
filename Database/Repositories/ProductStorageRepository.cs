using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class ProductStorageRepository : IRepository<ProductStorage>
{
    private readonly IEnumerable<DNS_practiceContext> _contexts;

    public ProductStorageRepository (IEnumerable<DNS_practiceContext> contexts)
    {
        _contexts = contexts;
    }

    public IEnumerable<IEnumerable<ProductStorage>> GetData ()
    {
        foreach (var context in _contexts)
            yield return context.ProductStorages.Include(e => e.Product)
                                                .Include(e => e.Document)
                                                .OrderBy(e => e.Product.Name)
                                                .ToList();
    }

    public IEnumerable<ProductStorage> FilterList (IEnumerable<ProductStorage> source, string query)
    {
        return source.Where(entity =>
                entity.DocumentId.ToString().Contains(query) ||
                entity.ProductId.ToString().Contains(query) ||
                entity.Product.Name.ToLower().Contains(query.ToLower()) ||
                entity.Document.Name.ToLower().Contains(query.ToLower()));
    }
}