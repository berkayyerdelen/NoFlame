using MediatR;
using NoFlame.Domain.EventAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoFlame.EventServices.Events.EventList
{
    public class GetEventListRequest : IRequest<List<GetEventListResponse>>
    {
    }
}
