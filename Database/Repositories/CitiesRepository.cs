using Database.Models;

namespace Database.Repositories;

public class CitiesRepository : IRepository<City>
{
    private readonly IEnumerable<DNS_practiceContext> _contexts;

    public CitiesRepository(IEnumerable<DNS_practiceContext> contexts)
    {
        _contexts = contexts;
    }

    public IEnumerable<IEnumerable<City>> GetData ()
    {
        foreach (var context in _contexts)
            yield return context.Cities.ToList();
    }

    public IEnumerable<City> FilterList (IEnumerable<City> source, string query)
    {
        return source.Where(city => city.Name.ToLower().Contains(query.ToLower()));
    }
}