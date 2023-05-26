namespace Database.Connections;

public interface IDatabase
{
    IEnumerable<T> Get<T>() where T : class;
}