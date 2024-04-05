using System;
using System.Collections.Generic;

namespace BlusukYogya.Domain;

public partial class Tag
{
    public int TagId { get; set; }

    public string TagName { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();
}
