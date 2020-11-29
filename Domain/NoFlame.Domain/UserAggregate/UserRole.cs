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
    public class UserRole:Entity
    {
        public UserRole()
        {
            CreationTime = DateTime.UtcNow;
            LastModificationTime = DateTime.UtcNow;
        }
        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
            CreationTime = DateTime.UtcNow;
            LastModificationTime = DateTime.UtcNow;
            this.AddDomainEvent(new SetUserRoleEvent(userId, roleId));
        }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public static UserRole CreateUserRole(Guid userId, Guid roleId)
        {
            return new UserRole(userId, roleId);
        }
    }
}
