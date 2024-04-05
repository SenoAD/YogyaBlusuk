using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlusukYogya.BLL.DTO
{
    public class ImageCreateDTO
    {

        public int PlaceId { get; set; }
        public IFormFile ImageFilePost { get; set; }
    }
}
