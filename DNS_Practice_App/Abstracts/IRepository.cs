using System.Collections.Generic;

namespace DNS_Practice_App.Abstracts;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetFromFirstDB ();

    IEnumerable<T> GetFromSecondDB ();

    IEnumerable<T> SearchFrom(IEnumerable<T> source, string query);
}