namespace Database.Models;

public class ProductStorage
{
    public Guid DocumentId { get; set; }
    public int DocumentType { get; set; }
    public short RecordKind { get; set; }
    public Guid ProductId { get; set; }
    public int ProductCount { get; set; }
}