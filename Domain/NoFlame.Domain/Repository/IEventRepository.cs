using NoFlame.Domain.EventAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoFlame.Domain.Repository
{
    public interface IEventRepository
    {
        Task<IList<Event>> GetEvents();
        Task<bool> DeleteEvents(IList<Guid> eventIds);
        Task<IList<Event>> GetEventsUndeleted();
    }
}
