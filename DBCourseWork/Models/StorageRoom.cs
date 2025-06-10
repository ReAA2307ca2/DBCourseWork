using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class StorageRoom
{
    public int Id { get; set; }

    public int? FkStorage { get; set; }

    public virtual Storage? FkStorageNavigation { get; set; }

    public virtual ICollection<StorageSection> StorageSections { get; set; } = new List<StorageSection>();
}
