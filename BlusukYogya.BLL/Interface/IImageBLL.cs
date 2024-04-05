using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.BLL.DTO;

namespace BlusukYogya.BLL.Interface
{
    public interface IImageBLL
    {
        Task<Task> Create(ImageCreateDTO entity, string imageUrl);
        Task<ImageDTO> Get(int id);
        Task<IEnumerable<ImageDTO>> GetAll();
        Task<Task> Update(ImageCreateDTO entity);
        Task<Task> Delete(int id);
        Task<IEnumerable<ImageDTO>> GetImagesByPlaceId(int placeId);
    }
}
