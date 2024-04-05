using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Domain;


namespace BlusukYogya.Data.Interface
{
    public interface IVacationPlanData : ICrudData<VacationPlan>
    {
        Task TransactionInsert(VacationPlan entity);
        Task<IEnumerable<VacationPlan>> GetVacationPlanByUserID(int userID);
        Task<VacationPlan> GetVacationPlanAndPlanItemByPlanID(int planID);
    }
}
