using System;
using System.Collections.Generic;

namespace AMS.Data;

public partial class Supplier
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public bool Status { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}
