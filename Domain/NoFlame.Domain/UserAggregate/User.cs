using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NoFlame.Domain.Base;
using NoFlame.Domain.UserAggregate.Events;

namespace NoFlame.Domain.UserAggregate
{
    public class User : Entity, IAggregateRoot
    {
        private User()
        {
            
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string LoginName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public bool IsActive { get; private set; }
    
        public User Activate()
        {
            IsActive = true;
            this.AddDomainEvent(new ActiveUserEvent(IsActive));
            return this;
        }

        public User Deactivate()
        {
            IsActive = false;
            this.AddDomainEvent(new DeActiveUserEvent(IsActive));
            return this;
        }

        protected User(string firstName, string lastName, string loginName, string password, string email, bool isActive)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            LoginName = loginName;
            Password = password;
            Email = email;
            IsActive = isActive;
            this.AddDomainEvent(new CreateUserEvent(Id, firstName, lastName, loginName, password, email, isActive));
        }    
        public static User CreateUser(string firstName, string lastName, string loginName, string password, string email, bool isActive)
        {
            return new User(firstName, lastName, loginName, password, email, isActive);
        }     
    }
}