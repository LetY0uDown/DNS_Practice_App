namespace Database;

public interface IRepository<T> where T : class
{
    IEnumerable<T> FilterList (IEnumerable<T> source, string query);
}