using MediatR;
using NoFlame.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.EventServices.Events.EventList
{
    public class GetEventListRequestHandler : IRequestHandler<GetEventListRequest, List<GetEventListResponse>>
    {
        public IEventRepository _eventRepository { get; set; }

        public GetEventListRequestHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public  Task<List<GetEventListResponse>> Handle(GetEventListRequest request, CancellationToken cancellationToken)
        {
            var source = _eventRepository.GetEvents().Result.Select(x => new GetEventListResponse()
            {
                Id = x.Id,
                EventBody = x.EventBody,
                EventName = x.EventName,
                IsDeleted = x.IsDeleted,
                TopicName = x.TopicName
            }).ToList();
            return Task.FromResult(source);
        }
    }
}
