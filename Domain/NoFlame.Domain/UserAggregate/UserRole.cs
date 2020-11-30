using NoFlame.Domain.Base;
using NoFlame.Domain.UserAggregate.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Domain.UserAggregate
{
    public class UserRole:ValueObjectBase
    {
        
        public UserRole()
        {
            
        }
        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
         
        }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
      

        public static UserRole CreateUserRole(Guid userId, Guid roleId)
        {
            return new UserRole(userId, roleId);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
