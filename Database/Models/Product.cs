namespace Database.Models;

public partial class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}