using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlusukYogya.Data.Interface;
using BlusukYogya.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlusukYogya.Data
{
    public class RoleData : IRoleData
    {
        private readonly YogyaBlusukContext _context;
        public RoleData(YogyaBlusukContext yogyaBlusukContext)
        {
            _context = yogyaBlusukContext;
        }
        public async Task<Task> AddUserToRole(int userId, int roleId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(c => c.UserId == userId);
            var role = await _context.Roles.FindAsync(roleId);

            role.Users.Add(user);
            await _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public async Task Create(Role entity)
        {
           await _context.Roles.AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var data = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<Role> Get(int id)
        {
            var data = await _context.Roles.FindAsync(id);
            return data;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            var data = await _context.Roles.ToListAsync();
            return data;
        }

        public Task Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
