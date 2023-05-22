using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.Repositories;

internal class CitiesRepository : IRepository<City>
{
    public IEnumerable<City> GetFromFirstDB ()
    {
        using DNS_practiceContext_One context = new();

        return context.Cities.ToList();
    }

    public IEnumerable<City> GetFromSecondDB ()
    {
        using DNS_practiceContext_Two context = new();

        return context.Cities.ToList();
    }
}