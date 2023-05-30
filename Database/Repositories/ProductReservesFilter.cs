using Database.Models;

namespace Database.Repositories;

public class ProductReservesFilter : IFilter<ProductReserve>
{
    public IEnumerable<ProductReserve> FilterList (IEnumerable<ProductReserve> source, string query)
    {
        return source.Where(entity =>
                entity.DocumentId.ToString().Contains(query) ||
                entity.ProductId.ToString().Contains(query) ||
                entity.Product.Name.ToLower().Contains(query.ToLower()) ||
                entity.Document.Name.ToLower().Contains(query.ToLower()));
    }
}
