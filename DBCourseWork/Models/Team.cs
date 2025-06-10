using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Team
{
    public int Id { get; set; }

    public int? FkTeamLeader { get; set; }

    public int? FkWorkType { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual TeamLeader? FkTeamLeaderNavigation { get; set; }

    public virtual WorkType? FkWorkTypeNavigation { get; set; }

    public virtual ICollection<Stage> Stages { get; set; } = new List<Stage>();
}
