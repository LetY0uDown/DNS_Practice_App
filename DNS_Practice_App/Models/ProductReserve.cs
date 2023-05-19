using System;
using System.Collections.Generic;

namespace DNS_Practice_App.Models
{
    public partial class ProductReserve
    {
        public Guid DocumentId { get; set; }
        public int DocumentType { get; set; }
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }

        public virtual Document Document { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
