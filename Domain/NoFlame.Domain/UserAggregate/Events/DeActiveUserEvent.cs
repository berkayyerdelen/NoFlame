using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Domain.UserAggregate.Events
{
    public class DeActiveUserEvent : INotification
    {
        public DeActiveUserEvent(bool isActive)
        {
            IsActive = isActive;
        }
        public bool IsActive { get; set; }
    }
}
