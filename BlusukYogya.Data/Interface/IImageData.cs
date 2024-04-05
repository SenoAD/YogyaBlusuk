using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Domain;

namespace BlusukYogya.Data.Interface
{
    public interface IImageData : ICrudData<Image>
    {
        Task<IEnumerable<Image>> GetImagesByPlaceId(int placeId);
    }
}
