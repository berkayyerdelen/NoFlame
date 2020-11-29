using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NoFlame.Core.Interfaces;
using NoFlame.Domain.Base;
using NoFlame.Domain.EventAggregate;
using NoFlame.Domain.UserAggregate;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NoFlame.Infrastructure.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Event> Events{ get; set; }
        
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
               CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEntities = this.ChangeTracker
                                     .Entries<Entity>()
                                     .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            var domainEvents = domainEntities
                               .SelectMany(x => x.Entity.DomainEvents)
                               .ToList();
            domainEntities.ForEach(entity => entity.Entity.ClearDomainEvents());
            foreach (var domainEvent in domainEvents)
            {
                var message =domainEvent.GetType();
                if (message.Name == null)
                    continue;

                var eventBody = JsonConvert.SerializeObject(domainEvent, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                });
                Console.WriteLine($"\n------\nA domain event has been published!\n" +
                                  $"Event: {message.Name}\n" +
                                  $"TopicName: {message.FullName}\n" +
                                  $"EventBody: {eventBody}\n");

                await Events.AddAsync(new Event(message.Name, eventBody, message.FullName), cancellationToken);
            }

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}