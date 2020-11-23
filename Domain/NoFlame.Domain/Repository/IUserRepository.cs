using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoFlame.Domain;
using NoFlame.Domain.Repository;
using NoFlame.Domain.UserAggregate;
namespace NoFlame.Domain.Repository
{
    public interface IUserRepository
    {
        Task InsertUser(User user);
        Task<User> UpdateUserActivity(Guid id, bool isActive);
        Task<bool> IsValidUserCredentials(string userName, string password);
        Task<IList<Role>> GetUserRoles(string userName);
    }
}