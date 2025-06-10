using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Furniture
{
    public int Id { get; set; }

    public int? FkOrder { get; set; }

    public string? Address { get; set; }

    public virtual Order? FkOrderNavigation { get; set; }
}
