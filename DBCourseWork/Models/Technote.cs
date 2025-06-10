using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Technote
{
    public int Id { get; set; }

    public int? FkOrder { get; set; }

    public string? Description { get; set; }

    public virtual Order? FkOrderNavigation { get; set; }

    public virtual ICollection<Stage> Stages { get; set; } = new List<Stage>();
}
