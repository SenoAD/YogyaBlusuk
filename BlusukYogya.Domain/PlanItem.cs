using System;
using System.Collections.Generic;

namespace BlusukYogya.Domain;

public partial class PlanItem
{
    public int ItemId { get; set; }

    public int PlanId { get; set; }

    public int PlaceId { get; set; }

    public DateTime PlanDate { get; set; }

    public virtual Place Place { get; set; } = null!;

    public virtual VacationPlan Plan { get; set; } = null!;
}
