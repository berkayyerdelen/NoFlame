using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Domain.UserAggregate.Events
{
    public class ActiveUserEvent: INotification
    {
        public bool IsActive { get; set; }
        public ActiveUserEvent(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
