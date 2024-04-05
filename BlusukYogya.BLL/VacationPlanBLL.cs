using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using BlusukYogya.Data.Interface;
using BlusukYogya.Domain;

namespace BlusukYogya.BLL
{
    public class VacationPlanBLL : IVacationPlanBLL
    {
        private readonly IVacationPlanData _vacationPlan;
        private readonly IMapper _mapper;
        public VacationPlanBLL(IVacationPlanData vacationPlanData, IMapper mapper)
        {
            _mapper = mapper;
            _vacationPlan = vacationPlanData;
        }

        public async Task<Task> Delete(int id)
        {
            await _vacationPlan.Delete(id);
            return Task.CompletedTask;
        }

        public Task<VacationPlanDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VacationPlanDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<VacationPlanDTO> GetVacationPlanAndPlanItemByPlanID(int planID)
        {
            var alldata = await _vacationPlan.GetVacationPlanAndPlanItemByPlanID(planID);
            var planData = _mapper.Map<List<PlanItemDTO>>(alldata.PlanItems);
            var dtoData = _mapper.Map<VacationPlanDTO>(alldata);
            dtoData.PlanItem = planData;
            return dtoData;
        }

        public async Task<IEnumerable<VacationPlanDTO>> GetVacationPlanByUserID(int userID)
        {
            var allData = await _vacationPlan.GetVacationPlanByUserID(userID);
            return _mapper.Map<IEnumerable<VacationPlanDTO>>(allData);
        }

        public async Task<Task> Insert(InsertVacationPlanDTO plan)
        {
            var dataDTO = _mapper.Map<VacationPlan>(plan);
            await _vacationPlan.TransactionInsert(dataDTO);
            return Task.CompletedTask;  
        }

        public async Task<Task> Update(VacationPlanDTO plan)
        {
            var data = _mapper.Map<VacationPlan>(plan);
            await _vacationPlan.Update(data);
            return Task.CompletedTask;
        }
    }
}
