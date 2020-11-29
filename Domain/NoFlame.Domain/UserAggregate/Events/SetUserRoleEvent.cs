using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Domain.UserAggregate.Events
{
    public class SetUserRoleEvent:INotification
    {
        public SetUserRoleEvent(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public Guid UserId { get;  set; }
        public Guid RoleId { get; set; }
    }
}
