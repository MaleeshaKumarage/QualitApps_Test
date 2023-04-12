using Microsoft.EntityFrameworkCore;
using QualitApps_Test.DataAccess;
using QualitApps_Test.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualitApps_Test.Services.Users
{
    public class UserService : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public BaseUser CreateUser(BaseUser user)
        {
            var createdUser = _context.Users.Add(user);
            _context.SaveChanges();
            return createdUser.Entity;
        }

        public List<BaseUser> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public BaseUser GetUserByUserId(Guid UserId)
        {
            var user = _context.Users.Find(UserId);


            return user;
        }

        public int RemoveUser(Guid UserId)
        {
            var user = _context.Users.Find(UserId);

            if (user == null)
            {
                return 0;
            }
            _context.Users.Remove(user);
            return _context.SaveChanges();

        }

        public async Task<BaseUser> UpdateUser(BaseUser user)
        {
            var u = _context.Users.FindAsync(user.UserId);
            var updatedUser = _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return updatedUser.Entity;
        }
    }
}
