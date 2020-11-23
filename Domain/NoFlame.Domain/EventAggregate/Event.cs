using NoFlame.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Domain.EventAggregate
{
    public class Event : Entity, IAggregateRoot
    {
        public Event(string eventName, string topicName, string eventBody, Guid? creatorUserId=default)
        {
            EventName = eventName;
            EventBody = eventBody;
            TopicName = topicName;
            CreatorUserId = creatorUserId;
            CreationTime = DateTime.Now;
            LastModifierUserId = creatorUserId;
            LastModificationTime = DateTime.Now;
        }
        public string EventName { get; private set; }
        public string TopicName { get; private set; }
        public string EventBody { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedTime { get; private set; }
        public Guid? DeletedUserId { get; private set; }
        public Event() { }

        public Event DeleteEvent(Guid userId= default)
        {
            IsDeleted = true;
            DeletedTime = DateTime.UtcNow;
            DeletedUserId = userId;
            return this;
        }
        public static Event CreateNewEvent(string eventName, string eventBody, string topicName, Guid creatorUserId)
        {
            return new Event(eventName, topicName, eventBody, creatorUserId);
        }

    }
}
