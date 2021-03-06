﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Domain.UserAggregate.Events
{
    public class CreateUserEvent: INotification
    {
        public CreateUserEvent(Guid id, string firstName, string lastName, string loginName, string password, string email, bool isActive)
        {
           
            LastName = lastName;
            LoginName = loginName;
            Password = password;
            Email = email;
            Id = id;
            FirstName = firstName;
            IsActive = isActive;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public bool IsActive { get; }
        public string LastName { get; }
        public string LoginName { get; }
        public string Password { get; }
        public string Email { get; }
    }
}
