using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Domain.UserAggregate.Events
{
    public class UpdateRoleNameEvent:INotification
    {
        public string RoleName { get; set; }
        public UpdateRoleNameEvent(string roleName)
        {
            RoleName = roleName;
        }
    }
}
