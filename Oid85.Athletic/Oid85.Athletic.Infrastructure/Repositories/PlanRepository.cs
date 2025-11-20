using Microsoft.EntityFrameworkCore;
using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Infrastructure.Entities;

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
                        Name = x.MorningTraining.Name,
                        TotalCountIterations = x.MorningTraining.TotalCountIterations,
                        TotalWeight = x.MorningTraining.TotalWeight
                    },
                    DayTraining = x.DayTraining == null ? null :
                    new Training
                    {
                        Id = x.DayTraining.Id,
                        Name = x.DayTraining.Name,
                        TotalCountIterations = x.DayTraining.TotalCountIterations,
                        TotalWeight = x.DayTraining.TotalWeight
                    }
                })
                .ToList();

            return result;
        }

        /// <inheritdoc/>
        public async Task<Guid?> SetDayTrainingAsync(DateOnly date, Guid trainingId)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = await context.PlanEntities
                .Include(x => x.MorningTraining)
                .Include(x => x.DayTraining)
                .FirstOrDefaultAsync(x => x.Date == date);

            var trainingEntity = await context.TrainingEntities.FirstOrDefaultAsync(x => x.Id == trainingId);

            if (entity is null)
            {
                entity = new PlanEntity
                {
                    Id = Guid.NewGuid(),
                    Date = date,
                    MorningTraining = null,
                    DayTraining = trainingEntity
                };

                await context.AddAsync(entity);
            }

            else
                entity.DayTraining = trainingEntity;
            
            await context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> SetMorningTrainingAsync(DateOnly date, Guid trainingId)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = await context.PlanEntities
                .Include(x => x.MorningTraining)
                .Include(x => x.DayTraining)
                .FirstOrDefaultAsync(x => x.Date == date);

            var trainingEntity = await context.TrainingEntities.FirstOrDefaultAsync(x => x.Id == trainingId);

            if (entity is null)
            {
                entity = new PlanEntity
                {
                    Id = Guid.NewGuid(),
                    Date = date,
                    MorningTraining = trainingEntity,
                    DayTraining = null
                };

                await context.AddAsync(entity);
            }

            else
                entity.MorningTraining = trainingEntity;

            await context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
