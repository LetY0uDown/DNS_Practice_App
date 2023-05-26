namespace Database.Models;

public class Document
{
    public Guid Id { get; set; }
    public int Type { get; set; }
    public string Name { get; set; } = null!;
}