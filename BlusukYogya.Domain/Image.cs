using System;
using System.Collections.Generic;

namespace BlusukYogya.Domain;

public partial class Image
{
    public int ImageId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int PlaceId { get; set; }

    public virtual Place Place { get; set; } = null!;
}
