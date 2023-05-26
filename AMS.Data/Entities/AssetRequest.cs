using System;
using System.Collections.Generic;

namespace AMS.Data;

public partial class AssetRequest
{
    public Guid Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Guid? AssetId { get; set; }

    public string? RequestComments { get; set; }

    public DateTime CreationDate { get; set; }

    public Guid? DepartmentId { get; set; }

    public string? AssetLocation { get; set; }

    public string? Number { get; set; }

    public Guid? EmployeeId { get; set; }

    public int? StatusId { get; set; }

    public Guid? CreatorId { get; set; }

    public string? NotesJson { get; set; }

    public string? AttachmentsJson { get; set; }

    public virtual Asset? Asset { get; set; }

    public virtual User? Creator { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Employee? Employee { get; set; }
}
