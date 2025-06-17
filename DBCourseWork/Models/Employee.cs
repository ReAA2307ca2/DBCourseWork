using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Employee
{
    public int Id { get; set; }

    public int? FkTeam { get; set; }

    public int? FkWorkplace { get; set; }

    public string? Name { get; set; }

    public int? FkRole { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual Role? FkRoleNavigation { get; set; }

    public virtual Team? FkTeamNavigation { get; set; }

    public virtual Workplace? FkWorkplaceNavigation { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
