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
        public async Task<Plan?> GetPlanByIdAsync(Guid planId)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = await context.PlanEntities
                .Include(x => x.DayTraining)
                .FirstOrDefaultAsync(x => x.Id == planId);

            if (entity is null)
                return null;

            var result = new Plan
            {
                Id = entity.Id,
                Date = entity.Date,
                DayTraining = entity.DayTraining == null ? null :
                    new Training
                    {
                        Id = entity.DayTraining.Id,
                        Name = entity.DayTraining.Name,
                        TotalCountIterations = entity.DayTraining.TotalCountIterations,
                        TotalWeight = entity.DayTraining.TotalWeight
                    }
            };

            return result;
        }

        /// <inheritdoc/>
        public async Task<List<Plan>?> GetPlansAsync(DateOnly from, DateOnly to)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entities = context.PlanEntities
                .Where(x => x.Date >= from)
                .Where(x => x.Date <= to)
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
                    DayTraining = x.DayTraining == null ? null :
                    new Training
                    {
                        Id = x.DayTraining.Id,
                        Name = x.DayTraining.Name,
                        Description = x.DayTraining.Description,
                        TotalCountIterations = x.DayTraining.TotalCountIterations,
                        TotalWeight = x.DayTraining.TotalWeight
                    }
                })
                .ToList();

            return result;
        }

        /// <inheritdoc/>
        public async Task<List<Plan>?> GetAllPlansAsync()
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entities = context.PlanEntities
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
        public async Task<Guid?> RemoveTrainingAsync(Guid planId, Guid trainingId)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = await context.PlanEntities
                .Include(x => x.DayTraining)
                .FirstOrDefaultAsync(x => x.Id == planId);

            if (entity is null)
                return null;

            if (entity.DayTraining is not null)
                if (entity.DayTraining.Id == trainingId)
                    entity.DayTraining = null;

            await context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> SetDayTrainingAsync(DateOnly date, Guid trainingId)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = await context.PlanEntities
                .Include(x => x.DayTraining)
                .FirstOrDefaultAsync(x => x.Date == date);

            var trainingEntity = await context.TrainingEntities.FirstOrDefaultAsync(x => x.Id == trainingId);

            if (entity is null)
            {
                entity = new PlanEntity
                {
                    Id = Guid.NewGuid(),
                    Date = date,
                    DayTraining = trainingEntity
                };

                await context.AddAsync(entity);
            }

            else
                entity.DayTraining = trainingEntity;
            
            await context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
