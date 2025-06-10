using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class StorageSection
{
    public int Id { get; set; }

    public int? FkRoom { get; set; }

    public virtual StorageRoom? FkRoomNavigation { get; set; }

    public virtual ICollection<StorageStockpile> StorageStockpiles { get; set; } = new List<StorageStockpile>();
}
