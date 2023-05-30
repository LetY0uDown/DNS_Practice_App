using Database.Models;

namespace Database.Repositories;

public class CitiesFilter : IFilter<City>
{
    public IEnumerable<City> FilterList (IEnumerable<City> source, string query)
    {
        return source.Where(city => city.Name.ToLower().Contains(query.ToLower()));
    }
}