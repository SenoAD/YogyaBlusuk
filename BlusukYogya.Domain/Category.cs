using System;
using System.Collections.Generic;

namespace BlusukYogya.Domain;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
