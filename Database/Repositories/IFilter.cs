namespace Database;

public interface IFilter<T> where T : class
{
    IEnumerable<T> FilterList (IEnumerable<T> source, string query);
}