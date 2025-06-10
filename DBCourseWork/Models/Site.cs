using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Site
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Workplace> Workplaces { get; set; } = new List<Workplace>();
}
