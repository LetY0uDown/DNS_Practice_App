using System;

namespace DNS_Practice_App.Models;

public partial class Storage
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public string Name { get; set; } = null!;

    public virtual City City { get; set; } = null!;
}