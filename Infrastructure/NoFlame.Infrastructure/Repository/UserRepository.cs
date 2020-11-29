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
        public async Task<List<string>> GetUserRoles(Guid id)
        {

            var roles = await (from userRole in _context.Set<UserRole>()
                               join role in _context.Set<Role>() on
                               userRole.RoleId equals role.Id
                               where userRole.UserId == id
                               select new
                               {
                                   Role = role.Name
                               }.Role).ToListAsync();


            return roles;
        }
        public async Task InsertUser(User user)
        {
            await _context.Set<User>().AddAsync(user);
            await _context.SaveChangesAsync(true, CancellationToken.None);
        }

        public async Task<Guid> IsValidUserCredentials(string userName, string password)
        {
            var userId = await _context.Set<User>().FirstOrDefaultAsync(x => x.LoginName == userName & x.Password == password);
            return userId.Id;
        }

        public async Task<User> UpdateUserActivity(Guid id, bool isActive)
        {
            var user = await _context.Set<User>().FindAsync(id);
            if (isActive == true)
                user.Activate();
            else user.Deactivate();
            await _context.SaveChangesAsync(true, CancellationToken.None);
            return user;
        }
        public async Task SetUserRole(Guid id, List<Guid> roleIds)
        {
            roleIds.ForEach(async roleId =>
            {
                await _context.Set<UserRole>().AddAsync(UserRole.CreateUserRole(id,roleId));
            });
            await _context.SaveChangesAsync(true, CancellationToken.None);
        }
    }
}