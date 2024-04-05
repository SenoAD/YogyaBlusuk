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
    public class UserData : IUserData
    {
        private readonly YogyaBlusukContext _context;
        public UserData(YogyaBlusukContext yogyaBlusukContext)
        {
            _context = yogyaBlusukContext;
        }

        public async Task<Task> ChangePassword(int userId, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return null;
            }
            user.Password = Helpers.Md5Hash.GetMD5Hash(newPassword);
            await _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public async Task Create(User entity)
        {
            entity.Password = Helpers.Md5Hash.GetMD5Hash(entity.Password);
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var user = await Get(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Get(int id)
        {
            var users = await _context.Users.FindAsync(id);
            return users;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public Task<IEnumerable<User>> GetAllWithRoles()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByUsername(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
        }

        public async Task<User> GetUserWithRoles(int userId)
        {
            var userWithRole = await _context.Users
                                        .Include(u => u.Roles) // Include roles
                                        .SingleOrDefaultAsync(x => x.UserId == userId);
            return userWithRole;
        }

        public async Task<User> Login(string username, string password)
        {
            var login = await _context.Users.SingleOrDefaultAsync(c => c.Username == username && c.Password == Helpers.Md5Hash.GetMD5Hash(password));
            return login;
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
