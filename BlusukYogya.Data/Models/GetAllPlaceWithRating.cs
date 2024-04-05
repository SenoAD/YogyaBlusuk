using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlusukYogya.Data.Models
{
    public class GetAllPlaceWithRating
    {
        public int PlaceID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int CategoryType { get; set; }
        public decimal? AveragePrice { get; set; }
        public decimal? AverageRating { get; set; }
        public string? Preview { get; set; }
    }

}
