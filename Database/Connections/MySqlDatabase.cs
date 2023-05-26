using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Connections;

public class MySqlDatabase : IDatabase
{
    private readonly MySqlContext _context;

    public MySqlDatabase(MySqlContext context)
    {
        _context = context;
    }

    public IEnumerable<T> Get<T> () where T : class
    {
        return _context.Set<T>().ToList();
    }
}

public class MySqlContext : DNSPracticeContext
{
    private readonly string _connectionString;

    public MySqlContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
    }
}