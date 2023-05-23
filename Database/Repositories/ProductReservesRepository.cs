using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class ProductReservesRepository : IRepository<ProductReserve>
{
    private readonly IEnumerable<DNS_practiceContext> _contexts;

    public ProductReservesRepository (IEnumerable<DNS_practiceContext> contexts)
    {
        _contexts = contexts;
    }

    public IEnumerable<IEnumerable<ProductReserve>> GetData ()
    {
        foreach (var context in _contexts)
            yield return context.ProductReserves.Include(e => e.Product).Include(e => e.Document).OrderBy(p => p.Product.Name).ToList();
    }

    public IEnumerable<ProductReserve> FilterList (IEnumerable<ProductReserve> source, string query)
    {
        return source.Where(entity =>
                entity.DocumentId.ToString().Contains(query) ||
                entity.ProductId.ToString().Contains(query) ||
                entity.Product.Name.ToLower().Contains(query.ToLower()) ||
                entity.Document.Name.ToLower().Contains(query.ToLower()));
    }
}
