﻿using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
