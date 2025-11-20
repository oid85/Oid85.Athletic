using Microsoft.EntityFrameworkCore;
using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Core.Models;

namespace Oid85.Athletic.Infrastructure.Repositories
{
    /// <inheritdoc/>
    public class PlanRepository(
        IDbContextFactory<AthleticContext> contextFactory)
        : IPlanRepository
    {
        /// <inheritdoc/>
        public async Task<List<Plan>?> GetPlansAsync(DateOnly from, DateOnly to)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entities = context.PlanEntities
                .Include(x => x.MorningTraining)
                .Include(x => x.DayTraining)
                .AsQueryable();

            if (entities is null)
                return null;

            entities = entities.OrderBy(x => x.Date);

            var filteredEntities = await entities.AsNoTracking().ToListAsync();

            if (filteredEntities is null)
                return null;

            var result = entities
                .Select(x => new Plan
                {
                    Id = x.Id,
                    Date = x.Date,
                    MorningTraining = x.MorningTraining == null ? null : 
                    new Training
                    {
                        Id = x.MorningTraining.Id,
                        Name = x.MorningTraining.Name
                    },
                    DayTraining = x.DayTraining == null ? null :
                    new Training
                    {
                        Id = x.DayTraining.Id,
                        Name = x.DayTraining.Name
                    }
                })
                .ToList();

            return result;
        }
    }
}
