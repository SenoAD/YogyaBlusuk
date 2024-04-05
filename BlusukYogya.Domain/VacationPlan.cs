using System;
using System.Collections.Generic;

namespace BlusukYogya.Domain;

public partial class VacationPlan
{
    public int PlanId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreateData { get; set; }

    public bool IsPublic { get; set; }

    public virtual ICollection<PlanItem> PlanItems { get; set; } = new List<PlanItem>();

    public virtual User User { get; set; } = null!;
}
