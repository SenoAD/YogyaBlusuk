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
    public class RoleBLL : IRoleBLL
    {
        private readonly IRoleData _role;
        private readonly IMapper _mapper;
        public RoleBLL(IRoleData roleData, IMapper mapper)
        {
            _mapper = mapper;
            _role = roleData;   
        }
        public async Task<Task> AddRole(RoleCreateDTO roleCreateDTO)
        {
            var data = _mapper.Map<Role>(roleCreateDTO);
            _role.Create(data);
            return Task.CompletedTask;
        }

        public async Task<Task> AddUserToRole(int userId, int roleId)
        {
            await _role.AddUserToRole(userId, roleId);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRoles()
        {
            var allData = await _role.GetAll();
            return _mapper.Map<IEnumerable<RoleDTO>>(allData);
        }
    }
}
