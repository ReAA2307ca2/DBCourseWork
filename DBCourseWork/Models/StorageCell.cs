using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class StorageCell
{
    public int Id { get; set; }

    public int? FkRack { get; set; }

    public virtual ICollection<Consumable> Consumables { get; set; } = new List<Consumable>();

    public virtual StorageRack? FkRackNavigation { get; set; }

    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
}
