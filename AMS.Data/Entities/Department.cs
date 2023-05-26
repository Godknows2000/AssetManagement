using System;
using System.Collections.Generic;

namespace AMS.Data;

public partial class Department
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual ICollection<AssetRequest> AssetRequests { get; set; } = new List<AssetRequest>();

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
