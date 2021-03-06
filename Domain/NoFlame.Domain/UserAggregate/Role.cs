﻿using NoFlame.Domain.Base;
using NoFlame.Domain.UserAggregate.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NoFlame.Domain.UserAggregate
{
    public class Role:Entity
    {        
        public string Name { get; private set; }
        private Role()
        {
            
        }
        protected Role(string roleName)
        {
            Name = roleName;
            CreationTime = DateTime.UtcNow;
            LastModificationTime = DateTime.UtcNow;
            this.AddDomainEvent(new CreateRoleEvent(roleName));
        }
        public static Role CreateRole(string roleName)
        {
            return new Role(roleName);
        } 
        public Role UpdateRoleName(string roleName)
        {
            Name = roleName;
            this.AddDomainEvent(new UpdateRoleNameEvent(roleName));
            return this;
        }
    }
}
