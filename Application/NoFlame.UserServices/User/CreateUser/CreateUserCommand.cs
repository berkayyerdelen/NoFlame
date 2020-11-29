using MediatR;
using NoFlame.Domain.UserAggregate;
using System.Collections.Generic;
using System.Security.Claims;

namespace NoFlame.UserServices.User.CreateUser
{
    public class CreateUserCommand: IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        
    }
}