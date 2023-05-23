using Database.Models;

namespace Database.Repositories;

public class DocumentsRepository : IRepository<Document>
{
    private readonly IEnumerable<DNS_practiceContext> _contexts;

    public DocumentsRepository (IEnumerable<DNS_practiceContext> contexts)
    {
        _contexts = contexts;
    }

    public IEnumerable<IEnumerable<Document>> GetData ()
    {
        foreach (var context in _contexts)
            yield return context.Documents.ToList();
    }

    public IEnumerable<Document> FilterList (IEnumerable<Document> source, string query)
    {
        return source.Where(e => e.Name.ToLower().Contains(query.ToLower()));
    }
}