using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlusukYogya.BLL.DTO
{
    public class TagCreateDTO
    {

        public string TagName { get; set; } = null!;

        public int CategoryId { get; set; }
    }
}
