using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.BLL.DTO;
using BlusukYogya.Domain;

namespace BlusukYogya.BLL.Interface
{
    public interface ITagBLL
    {
        Task<Task> Create(TagCreateDTO entity);
        Task<TagDTO> Get(int id);
        Task<IEnumerable<TagDTO>> GetAll();
        Task<Task> Update(TagCreateDTO entity);
        Task<Task> Delete(int id);
        Task<IEnumerable<TagDTO>> GetTagsByCategoryID(int categoryID);
        Task<IEnumerable<TagDTO>> GetTagsByPlaceID(int placeID);
    }
}
