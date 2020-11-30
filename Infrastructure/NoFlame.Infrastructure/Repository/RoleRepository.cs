using Microsoft.EntityFrameworkCore;
using NoFlame.Core.Interfaces;
using NoFlame.Domain.Repository;
using NoFlame.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.Infrastructure.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private IApplicationContext _context;

        public RoleRepository(IApplicationContext context)
        {
            _context = context;
        }
        public async Task CreateRole(string roleName)
        {
            await _context.Set<Role>().AddAsync(Role.CreateRole(roleName));
            await _context.SaveChangesAsync(true,CancellationToken.None);
        }

        public async Task<bool> DeleteRole(Guid id)
        {
            var role =await _context.Set<Role>().FindAsync(id);
            _context.Set<Role>().Remove(role);
            return await _context.SaveChangesAsync(true,CancellationToken.None)==1;
        }

        public async Task<List<Role>> GetRoles()
        {
            return await _context.Set<Role>().ToListAsync(CancellationToken.None);
        }

        public async Task<bool> UpdateRole(Guid id, string roleName)
        {
            var role = await _context.Set<Role>().FindAsync(id);
            role.UpdateRoleName(roleName);
            role.LastModificationTime = DateTime.UtcNow;
            return await _context.SaveChangesAsync(true,CancellationToken.None) == 1;
        }
    }
}
