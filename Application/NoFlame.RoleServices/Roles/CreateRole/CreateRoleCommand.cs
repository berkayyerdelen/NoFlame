using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoFlame.RoleServices.Roles.CreateRole
{
    public class CreateRoleCommand: IRequest
    {
        public string Name { get; set; }

        public CreateRoleCommand(string name)
        {
            Name = name;
        }
    }
}
