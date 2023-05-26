using System;
using System.Collections.Generic;

namespace AMS.Data;

public partial class Asset
{
    public Guid Id { get; set; }

    public string AssetId { get; set; } = null!;

    public string? Barcode { get; set; }

    public string Name { get; set; } = null!;

    public string? Model { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string Price { get; set; } = null!;

    public Guid? SupplierId { get; set; }

    public Guid? DepartmentId { get; set; }

    public string? ImageFile { get; set; }

    public string? AssetReceipt { get; set; }

    public DateTime CreationDate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<AssetRequest> AssetRequests { get; set; } = new List<AssetRequest>();

    public virtual Department? Department { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
