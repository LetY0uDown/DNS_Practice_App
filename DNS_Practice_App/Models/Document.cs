using System;
using System.Collections.Generic;

namespace DNS_Practice_App.Models
{
    public partial class Document
    {
        public Guid Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; } = null!;
    }
}
