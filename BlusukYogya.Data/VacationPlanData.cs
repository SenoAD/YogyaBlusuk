using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using BlusukYogya.Data.Interface;
using BlusukYogya.Domain;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlusukYogya.Data
{
    public class VacationPlanData : IVacationPlanData
    {
        private readonly YogyaBlusukContext _context;
        public VacationPlanData(YogyaBlusukContext yogyaBlusukContext)
        {
            _context = yogyaBlusukContext;
        }
        public Task Create(VacationPlan entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var dataItem = await _context.PlanItems.Where(c => c.PlanId == id).ToListAsync();
                    
                    foreach (var item in dataItem) 
                    {
                        _context.PlanItems.Remove(item);
                    }
                    
                    var dataPlan = await _context.VacationPlans.FindAsync(id);
                    _context.VacationPlans.Remove(dataPlan);
                    await _context.SaveChangesAsync();

                    transaction.Commit(); // Commit the transaction if all operations succeed
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Rollback the transaction if any operation fails
                }
            }
            
        }

        public async Task<VacationPlan> Get(int id)
        {
            var data = await _context.VacationPlans.FindAsync(id);
            return data;
        }

        public async Task<IEnumerable<VacationPlan>> GetAll()
        {
            var allData = await _context.VacationPlans.ToListAsync();
            return allData;
        }

        public async Task<VacationPlan> GetVacationPlanAndPlanItemByPlanID(int planID)
        {
            var data = await _context.VacationPlans.Where(c=>c.PlanId == planID).Include(c=>c.PlanItems).SingleAsync();
            return data;
        }

        public async Task<IEnumerable<VacationPlan>> GetVacationPlanByUserID(int userID)
        {
            var data = await _context.VacationPlans.Where(c=>c.UserId == userID).ToListAsync();
            return data;
        }

        public async Task TransactionInsert(VacationPlan entity)
        {
                    _context.VacationPlans.Add(entity);
                    await _context.SaveChangesAsync();
        }


        public async Task Update(VacationPlan entity)
        {
            var data = await _context.VacationPlans.Include(c => c.PlanItems).Where(c=> c.PlanId == entity.PlanId).SingleOrDefaultAsync();
            
            data.Name = entity.Name;
            data.Description = entity.Description;
            data.IsPublic = entity.IsPublic;
            data.PlanItems = entity.PlanItems;
            await _context.SaveChangesAsync();
        }
    }
}
