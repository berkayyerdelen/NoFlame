using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoFlame.Core.Interfaces;
using NoFlame.Domain.Repository;
using NoFlame.Domain.UserAggregate;

namespace NoFlame.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationContext _context;

        public UserRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList<Role>> GetUserRoles(string userName)
        {
            var userRole = await _context.Set<User>().Include(x=>x.Roles).FirstOrDefaultAsync(x => x.LoginName == userName);
            return userRole.Roles;
        }

        public async Task InsertUser(User user)
        {
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync(true,CancellationToken.None);
        }

        public async Task<bool> IsValidUserCredentials(string userName, string password)
        {
            return await _context.Set<User>().AnyAsync(x => x.LoginName == userName && x.Password == password);
        }

        public async Task<User> UpdateUserActivity(Guid id, bool isActive)
        {
           var user = await _context.Set<User>().FindAsync(id);
           if (isActive == true)
               user.Activate();
           else user.Deactivate();
           await _context.SaveChangesAsync(true,CancellationToken.None);
           return user;
        }

        
    }
}