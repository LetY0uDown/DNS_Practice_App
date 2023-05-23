namespace Database;

public interface IRepository<T> where T : class
{
    IEnumerable<IEnumerable<T>> GetData();

    IEnumerable<T> FilterList (IEnumerable<T> source, string query);
}