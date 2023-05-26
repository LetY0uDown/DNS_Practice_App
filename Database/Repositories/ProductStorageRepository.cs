using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class ProductStorageRepository : IRepository<ProductStorage>
{
    public IEnumerable<ProductStorage> FilterList (IEnumerable<ProductStorage> source, string query)
    {
        return source.Where(entity =>
                entity.DocumentId.ToString().Contains(query) ||
                entity.ProductId.ToString().Contains(query));
    }
}