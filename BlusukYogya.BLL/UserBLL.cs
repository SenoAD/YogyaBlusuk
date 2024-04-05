using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlusukYogya.BLL.DTO;
using BlusukYogya.BLL.Interface;
using BlusukYogya.Data;
using BlusukYogya.Data.Interface;
using BlusukYogya.Domain;

namespace BlusukYogya.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserData _user;
        private readonly IMapper _mapper;
        public UserBLL(IUserData userData, IMapper mapper)
        {
            _mapper = mapper;
            _user = userData;   
        }
        public async Task<Task> ChangePassword(int userId, string newPassword)
        {
            await _user.ChangePassword(userId, newPassword);
            return Task.CompletedTask;
        }

        public async Task<Task> Delete(int userId)
        {
            await _user.Delete(userId);
            return Task.CompletedTask;  
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var allData = await _user.GetAll();
            return _mapper.Map<IEnumerable<UserDTO>>(allData);
        }

        public Task<IEnumerable<UserDTO>> GetAllWithRoles()
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByUsername(string username)
        {
            var data = await _user.GetByUsername(username);
            return _mapper.Map<UserDTO>(data);
        }

        public async Task<UserDTO> GetUserWithRoles(int userId)
        {
            var userWithRole = await _user.GetUserWithRoles(userId);
            return _mapper.Map<UserDTO>(userWithRole);
        }

        public async Task<Task> Insert(UserCreateDTO entity)
        {
            var data = _mapper.Map<User>(entity);
            await _user.Create(data);
            return Task.CompletedTask;
        }

        public async Task<UserDTO> Login(string username, string password)
        {
            var user = await _user.Login(username, password);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
