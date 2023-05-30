using Database.Models;

namespace Database.Repositories;

public class ProductStorageFilter : IFilter<ProductStorage>
{
    public IEnumerable<ProductStorage> FilterList (IEnumerable<ProductStorage> source, string query)
    {
        return source.Where(entity =>
                entity.DocumentId.ToString().Contains(query) ||
                entity.ProductId.ToString().Contains(query));
    }
}