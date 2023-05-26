namespace Database.Models;

public class ProductReserve
{
    public Guid DocumentId { get; set; }
    public int DocumentType { get; set; }
    public Guid ProductId { get; set; }
    public int ProductCount { get; set; }

    public Document Document { get; set; } = null!;
    public Product Product { get; set; } = null!;
}