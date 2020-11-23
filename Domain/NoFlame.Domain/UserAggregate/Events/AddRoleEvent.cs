using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Domain.UserAggregate.Events
{
    public class AddRoleEvent: INotification
    {
        public Role Role { get; set; }
        public AddRoleEvent(Role role)
        {
            Role = role;

        }
    }
}
