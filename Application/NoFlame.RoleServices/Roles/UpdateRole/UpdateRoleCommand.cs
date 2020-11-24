using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoFlame.RoleServices.Roles.UpdateRole
{
    public class UpdateRoleCommand : IRequest
    {
        public UpdateRoleCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
