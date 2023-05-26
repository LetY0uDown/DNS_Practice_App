namespace Database.Models;

public class Storage
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public string Name { get; set; } = null!;
}