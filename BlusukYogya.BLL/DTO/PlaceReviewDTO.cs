using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlusukYogya.BLL.DTO
{
    public class PlaceReviewDTO
    {
        public int ReviewId { get; set; }

        public int UserId { get; set; }

        public int PlaceId { get; set; }

        public string? ReviewText { get; set; }

        public decimal Rating { get; set; }

        public DateTime Date { get; set; }
    }
}
