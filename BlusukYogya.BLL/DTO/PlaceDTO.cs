using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlusukYogya.BLL.DTO
{
    public class PlaceDTO
    {
        public int PlaceId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        public int? CategoryType { get; set; }

        public decimal? AveragePrice { get; set; }
        public string? Preview { get; set; }

    }
}
