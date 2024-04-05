using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlusukYogya.BLL.DTO
{
    public class InsertVacationPlanDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<InsertPlanItemDTO> PlanItems { get; set; }
    }
}
