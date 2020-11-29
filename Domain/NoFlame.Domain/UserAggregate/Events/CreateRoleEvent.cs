using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Domain.UserAggregate.Events
{
    public class CreateRoleEvent: INotification
    {
        public string RoleName { get; set; }
        public CreateRoleEvent(string roleName)
        {
            RoleName = roleName;
        }
        public CreateRoleEvent()
        {

        }
    }
}
