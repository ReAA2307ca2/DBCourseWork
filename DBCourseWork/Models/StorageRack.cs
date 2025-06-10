using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class StorageRack
{
    public int Id { get; set; }

    public int? FkStockpile { get; set; }

    public virtual StorageStockpile? FkStockpileNavigation { get; set; }

    public virtual ICollection<StorageCell> StorageCells { get; set; } = new List<StorageCell>();
}
