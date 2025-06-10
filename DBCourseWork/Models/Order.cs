using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? FkClient { get; set; }

    public string? Description { get; set; }

    public virtual Client? FkClientNavigation { get; set; }

    public virtual ICollection<Furniture> Furnitures { get; set; } = new List<Furniture>();

    public virtual ICollection<Part> Parts { get; set; } = new List<Part>();

    public virtual ICollection<Technote> Technotes { get; set; } = new List<Technote>();
}
