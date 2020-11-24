using NoFlame.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Domain.Repository
{
    public interface IRoleRepository
    {
        Task CreateRole(string roleName);
        Task<bool> DeleteRole(Guid id);
        Task<bool> UpdateRole(Guid id, string roleName);
        Task<List<Role>> GetRoles();
    }
}
