using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class ConsumablesType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Consumable> Consumables { get; set; } = new List<Consumable>();
}
