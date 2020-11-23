using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Domain.UserAggregate.Events
{
    public class CreateUserWithRolesEvent : INotification
    {
        public CreateUserWithRolesEvent(Guid id, string firstName, string lastName, string loginName, string password, string email, IList<Role> roles, bool isActive)
        {
            LastName = lastName;
            LoginName = loginName;
            Password = password;
            Email = email;
            İd = id;
            FirstName = firstName;
            Roles = roles;
            IsActive = isActive;
        }

        public Guid İd { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string LoginName { get; }
        public string Password { get; }
        public string Email { get; }
        public IList<Role> Roles { get; set; }
        public bool IsActive { get; }
    }
}
