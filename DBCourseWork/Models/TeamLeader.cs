using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class TeamLeader
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
