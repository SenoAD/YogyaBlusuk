using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.BLL.DTO;

namespace BlusukYogya.BLL.Interface
{
    public interface IUserBLL
    {
        Task<Task> ChangePassword(int userId, string newPassword);
        Task<Task> Delete(int userId);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetByUsername(string username);
        Task<Task> Insert(UserCreateDTO entity);
        Task<UserDTO> Login(string username, string password);

        Task<UserDTO> GetUserWithRoles(int userId);
        Task<IEnumerable<UserDTO>> GetAllWithRoles();
    }
}
