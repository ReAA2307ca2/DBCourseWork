using System;
using System.Collections.Generic;

namespace DBCourseWork.Models;

public partial class Operation
{
    public int Id { get; set; }

    public int? FkStage { get; set; }

    public int? FkMachine { get; set; }

    public int? FkEmployee { get; set; }

    public int? FkConsumables { get; set; }

    public DateTime? StartTime { get; set; }

    public virtual StageConsumable? FkConsumablesNavigation { get; set; }

    public virtual Employee? FkEmployeeNavigation { get; set; }

    public virtual Machine? FkMachineNavigation { get; set; }

    public virtual Stage? FkStageNavigation { get; set; }
}
