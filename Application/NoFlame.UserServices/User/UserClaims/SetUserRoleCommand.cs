using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoFlame.UserServices.User.UserClaims
{
    public class SetUserRoleCommand : IRequest
    {
        public Guid UserId { get; set; }
        public List<Guid> RoleIds { get; set; }
    }
}
