using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlusukYogya.BLL.DTO
{
    public class VacationPlanDTO
    {
        public int PlanId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreateData { get; set; }

        public bool IsPublic { get; set; }
        public List<PlanItemDTO> PlanItem { get; set; }
    }
}
