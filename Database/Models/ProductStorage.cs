namespace Database.Models;

public partial class ProductStorage
{
    public Guid DocumentId { get; set; }
    public int DocumentType { get; set; }
    public short RecordKind { get; set; }
    public Guid ProductId { get; set; }
    public int ProductCount { get; set; }

    public virtual Document Document { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}