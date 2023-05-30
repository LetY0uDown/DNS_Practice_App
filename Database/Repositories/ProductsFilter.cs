using Database.Models;

namespace Database.Repositories;

public class ProductsFilter : IFilter<Product>
{
    public IEnumerable<Product> FilterList (IEnumerable<Product> source, string query)
    {
        return source.Where(e => e.Name.ToLower().Contains(query.ToLower()) || e.Id.ToString().Contains(query));
    }
}