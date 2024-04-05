using System.Numerics;
using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using BlusukYogya.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlusukYogya.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationPlansController : ControllerBase
    {
        private readonly IVacationPlanBLL _vacationPlan;
        public VacationPlansController(IVacationPlanBLL vacationPlanBLL)
        {
            _vacationPlan = vacationPlanBLL;
        }

        [HttpPost("InsertNew")]
        public async Task<IActionResult> InsertNewVacationPlan(InsertVacationPlanDTO insertVacationPlanDTO)
        {
            {
                var result = await _vacationPlan.Insert(insertVacationPlanDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            {
                var result = await _vacationPlan.Delete(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(VacationPlanDTO vacationPlanDTO)
        {
            {
                var result = await _vacationPlan.Update(vacationPlanDTO);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId(int id)
        {
            {
                var result = await _vacationPlan.GetVacationPlanByUserID(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        [HttpGet("GetAllByPlanId")]
        public async Task<IActionResult> GetByPlanId(int id)
        {
            {
                var result = await _vacationPlan.GetVacationPlanAndPlanItemByPlanID(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}
