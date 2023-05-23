using Database.Models;

namespace Database.Repositories;

public class ProductsRepository : IRepository<Product>
{
    private readonly IEnumerable<DNS_practiceContext> _contexts;

    public ProductsRepository (IEnumerable<DNS_practiceContext> contexts)
    {
        _contexts = contexts;
    }

    public IEnumerable<IEnumerable<Product>> GetData ()
    {
        foreach (var context in _contexts)
            yield return context.Products.ToList();
    }

    public IEnumerable<Product> FilterList (IEnumerable<Product> source, string query)
    {
        return source.Where(e => e.Name.ToLower().Contains(query.ToLower()) || e.Id.ToString().Contains(query));
    }
}