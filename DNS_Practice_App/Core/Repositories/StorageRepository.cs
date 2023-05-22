using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.Repositories;

internal class StorageRepository : IRepository<Storage>
{
    public IEnumerable<Storage> GetFromFirstDB ()
    {
        using DNS_practiceContext_One context = new();

        return context.Storages.ToList();
    }

    public IEnumerable<Storage> GetFromSecondDB ()
    {
        using DNS_practiceContext_Two context = new();

        return context.Storages.ToList();
    }
}