using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Consumable
{
    public int Id { get; set; }

    public int? FkType { get; set; }

    public int? FkStorageCell { get; set; }

    public string? Name { get; set; }

    public virtual StorageCell? FkStorageCellNavigation { get; set; }

    public virtual ConsumablesType? FkTypeNavigation { get; set; }

    public virtual ICollection<StageConsumable> StageConsumables { get; set; } = new List<StageConsumable>();
}
