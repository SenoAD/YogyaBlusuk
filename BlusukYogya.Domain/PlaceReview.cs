using System;
using System.Collections.Generic;

namespace BlusukYogya.Domain;

public partial class PlaceReview
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public int PlaceId { get; set; }

    public string? ReviewText { get; set; }

    public decimal Rating { get; set; }

    public DateTime Date { get; set; }

    public virtual Place Place { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
