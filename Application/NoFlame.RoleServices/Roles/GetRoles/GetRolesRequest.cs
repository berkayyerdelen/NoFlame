using MediatR;
using NoFlame.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoFlame.RoleServices.Roles.GetRoles
{
    public class GetRolesRequest:IRequest<List<Role>>
    {
    }
}
