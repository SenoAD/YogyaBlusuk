using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.BLL.DTO;
using BlusukYogya.Data;
using BlusukYogya.Domain;

namespace BlusukYogya.BLL.Interface
{
    public interface IVacationPlanBLL
    {
        Task<Task> Delete(int id);
        Task<Task> Insert(InsertVacationPlanDTO plan);
        Task<IEnumerable<VacationPlanDTO>> GetVacationPlanByUserID(int userID);
        Task<Task> Update(VacationPlanDTO plan);
        Task<VacationPlanDTO> Get(int id);
        Task<IEnumerable<VacationPlanDTO>> GetAll();
        Task<VacationPlanDTO> GetVacationPlanAndPlanItemByPlanID(int planID);
        //GetEditVacationPlanDTO GetVacationPlanAndPlanItemByPlanID(int planID);
    }
}
