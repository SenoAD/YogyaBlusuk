using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlusukYogya.BLL.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Username { get; set; } 

        public string Password { get; set; } 

        public string Email { get; set; } 

        public string FirstName { get; set; } 

        public string LastName { get; set; }

        public IEnumerable<RoleDTO> Roles { get; set; }
    }
}
