using DNS_Practice_App.Abstracts;
using DNS_Practice_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace DNS_Practice_App.Core.Repositories;

internal class DocumentsRepository : IRepository<Document>
{
    public IEnumerable<Document> GetFromFirstDB ()
    {
        using DNS_practiceContext_One context = new();

        return context.Documents.ToList();
    }

    public IEnumerable<Document> GetFromSecondDB ()
    {
        using DNS_practiceContext_Two context = new();

        return context.Documents.ToList();
    }
}