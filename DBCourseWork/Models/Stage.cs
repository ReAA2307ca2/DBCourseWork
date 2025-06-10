using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Stage
{
    public int Id { get; set; }

    public int? FkTeam { get; set; }

    public int? FkTechnode { get; set; }

    public virtual Team? FkTeamNavigation { get; set; }

    public virtual Technote? FkTechnodeNavigation { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();

    public virtual ICollection<StageConsumable> StageConsumables { get; set; } = new List<StageConsumable>();
}
