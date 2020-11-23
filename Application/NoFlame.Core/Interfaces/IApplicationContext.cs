using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NoFlame.Core.Interfaces
{
    public interface IApplicationContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
               CancellationToken cancellationToken);
    }
}