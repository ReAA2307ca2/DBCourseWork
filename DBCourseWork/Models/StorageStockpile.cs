using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class StorageStockpile
{
    public int Id { get; set; }

    public int? FkSection { get; set; }

    public virtual StorageSection? FkSectionNavigation { get; set; }

    public virtual ICollection<StorageRack> StorageRacks { get; set; } = new List<StorageRack>();
}
