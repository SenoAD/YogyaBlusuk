using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Domain;

namespace BlusukYogya.Data.Interface
{
    public interface ITagData : ICrudData<Tag>
    {
        Task<IEnumerable<Tag>> GetTagsByCategoryID (int categoryID);
        Task<IEnumerable<Tag>> GetTagsByPlaceID (int placeID);
    }
}
