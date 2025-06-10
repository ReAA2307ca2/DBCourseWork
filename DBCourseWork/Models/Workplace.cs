using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Workplace
{
    public int Id { get; set; }

    public int? FkSite { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Site? FkSiteNavigation { get; set; }

    public virtual ICollection<Machine> Machines { get; set; } = new List<Machine>();
}
