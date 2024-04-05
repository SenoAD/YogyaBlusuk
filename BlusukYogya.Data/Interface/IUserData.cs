using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Domain;

namespace BlusukYogya.Data.Interface
{
    public interface IUserData : ICrudData<User>
    {
        Task<IEnumerable<User>> GetAllWithRoles();
        Task<User> GetUserWithRoles(int userId);
        Task<User> GetByUsername(string username);
        Task<User> Login(string username, string password);
        Task<Task> ChangePassword(int userId, string newPassword);
    }
}
