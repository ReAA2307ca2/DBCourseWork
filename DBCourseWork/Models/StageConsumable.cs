using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class StageConsumable
{
    public int Id { get; set; }

    public int? FkStage { get; set; }

    public int? FkConsumable { get; set; }

    public virtual Consumable? FkConsumableNavigation { get; set; }

    public virtual Stage? FkStageNavigation { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
