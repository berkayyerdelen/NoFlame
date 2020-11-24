using System;

namespace NoFlame.EventServices.Events.EventList
{
    public class GetEventListResponse
    {
        public Guid Id { get; set; }
        public string EventName { get; set; }
        public string TopicName { get; set; }
        public string EventBody { get; set; }
        public bool IsDeleted { get; set; }
    }
}