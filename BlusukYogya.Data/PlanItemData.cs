using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Data.Interface;
using BlusukYogya.Domain;

namespace BlusukYogya.Data
{
    public class PlanItemData : IPlanItemData
    {
        public Task Create(PlanItem entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlanItem> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlanItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(PlanItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
