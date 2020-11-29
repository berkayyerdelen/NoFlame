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
        public User()
        {
            
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    
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

        public User(Guid id, string firstName, string lastName, string loginName, string password, string email, bool isActive)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            LoginName = loginName;
            Password = password;
            Email = email;
            IsActive = isActive;
            this.AddDomainEvent(new CreateUserEvent(id, firstName, lastName, loginName, password, email, isActive));
        }    
        public static User CreateUser(Guid id, string firstName, string lastName, string loginName, string password, string email, bool isActive)
        {
            return new User(id, firstName, lastName, loginName, password, email, isActive);
        }     
    }
}