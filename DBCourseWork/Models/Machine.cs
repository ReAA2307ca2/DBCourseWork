using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Machine
{
    public int Id { get; set; }

    public int? FkWorkplace { get; set; }

    public string? Name { get; set; }

    public virtual Workplace? FkWorkplaceNavigation { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
