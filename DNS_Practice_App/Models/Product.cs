using System;
using System.Collections.Generic;

namespace DNS_Practice_App.Models
{
    public partial class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
