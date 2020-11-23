using Microsoft.EntityFrameworkCore;
using NoFlame.Core.Interfaces;
using NoFlame.Domain.EventAggregate;
using NoFlame.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.Infrastructure.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly IApplicationContext _context;

        public EventRepository(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteEvents(IList<Guid> eventIds)
        {

            var events = await _context.Set<Event>().Where(e => eventIds.Contains(e.Id)).ToListAsync(CancellationToken.None);
            events.ForEach(e => e.DeleteEvent());
            _context.Set<Event>().UpdateRange(events);
            return await _context.SaveChangesAsync(true,CancellationToken.None) == 1;
        }
     
        public async Task<IList<Event>> GetEvents()
            => await _context.Set<Event>().ToListAsync(CancellationToken.None);
        public async Task<IList<Event>> GetEventsUndeleted() 
            => await _context.Set<Event>().Where(x => x.IsDeleted == false).ToListAsync(CancellationToken.None);
    }
}
