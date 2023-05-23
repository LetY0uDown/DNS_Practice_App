using Database.Models;

namespace Database.Repositories;

public class StorageRepository : IRepository<Storage>
{
    private readonly IEnumerable<DNS_practiceContext> _contexts;

    public StorageRepository (IEnumerable<DNS_practiceContext> contexts)
    {
        _contexts = contexts;
    }

    public IEnumerable<IEnumerable<Storage>> GetData ()
    {
        foreach (var context in _contexts)
            yield return context.Storages.ToList();
    }

    public IEnumerable<Storage> FilterList (IEnumerable<Storage> source, string query)
    {
        return source.Where(e => e.Name.ToLower().Contains(query.ToLower()) || e.City.Name.ToLower().Contains(query.ToLower()));
    }
}