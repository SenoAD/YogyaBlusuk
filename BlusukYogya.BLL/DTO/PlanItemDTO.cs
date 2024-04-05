using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlusukYogya.BLL.DTO
{
    public class PlanItemDTO
    {
        public int ItemId { get; set; }

        public int PlanId { get; set; }

        public int PlaceId { get; set; }

        public DateTime PlanDate { get; set; }
    }
}
