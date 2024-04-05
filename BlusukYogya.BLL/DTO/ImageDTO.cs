using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlusukYogya.BLL.DTO
{
    public class ImageDTO
    {
        public int ImageId { get; set; }

        public string ImageUrl { get; set; } = null!;

        public int PlaceId { get; set; }
    }
}
