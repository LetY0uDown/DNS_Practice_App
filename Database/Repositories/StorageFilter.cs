using Database.Models;

namespace Database.Repositories;

public class StorageFilter : IFilter<Storage>
{
    public IEnumerable<Storage> FilterList (IEnumerable<Storage> source, string query)
    {
        return source.Where(e => e.Name.ToLower().Contains(query.ToLower()));
    }
}