using Database.Models;

namespace Database.Repositories;

public class DocumentsFilter : IFilter<Document>
{
    public IEnumerable<Document> FilterList (IEnumerable<Document> source, string query)
    {
        return source.Where(e => e.Name.ToLower().Contains(query.ToLower()));
    }
}