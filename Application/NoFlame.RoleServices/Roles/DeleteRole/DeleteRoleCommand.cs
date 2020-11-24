using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoFlame.RoleServices.Roles.DeleteRole
{
    public class DeleteRoleCommand:IRequest
    {
        public Guid Id { get; set; }
        public DeleteRoleCommand(Guid id)
        {
            Id = id;
        }
    }
}
