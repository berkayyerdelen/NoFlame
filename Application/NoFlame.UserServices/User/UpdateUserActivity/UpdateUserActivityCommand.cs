using System;
using MediatR;

namespace NoFlame.UserServices.User.UpdateUserActivity
{
    public class UpdateUserActivityCommand:IRequest<Domain.UserAggregate.User>
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}