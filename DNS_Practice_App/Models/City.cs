using System;
using System.Collections.Generic;

namespace DNS_Practice_App.Models;

public partial class City
{
    public City ()
    {
        Storages = new HashSet<Storage>();
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<Storage> Storages { get; set; }
}