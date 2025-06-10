using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Part
{
    public int Id { get; set; }

    public int? FkOrder { get; set; }

    public int? FkStorageCell { get; set; }

    public string? Name { get; set; }

    public virtual Order? FkOrderNavigation { get; set; }

    public virtual StorageCell? FkStorageCellNavigation { get; set; }
}
