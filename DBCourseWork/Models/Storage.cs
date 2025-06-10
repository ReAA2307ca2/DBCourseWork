using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Storage
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<StorageRoom> StorageRooms { get; set; } = new List<StorageRoom>();
}
