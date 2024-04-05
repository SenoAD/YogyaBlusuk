using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BlusukYogya.BLL.DTO
{
    public class PlaceCreateDTO
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? Location { get; set; }

        public int? CategoryType { get; set; }

        public decimal? AveragePrice { get; set; }
        public IFormFile ImageFilePost { get; set; }
    }
}
