using Microsoft.EntityFrameworkCore;
using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Infrastructure.Entities;

namespace Oid85.Athletic.Infrastructure.Repositories
{
    /// <inheritdoc/>
    public class TrainingRepository(
        IDbContextFactory<AthleticContext> contextFactory)
        : ITrainingRepository
    {
        /// <inheritdoc/>
        public async Task<Guid?> CreateTrainingAsync(Training model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = new TrainingEntity
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Cycles = model.Cycles,
                StartCardioMinutes = model.StartCardioMinutes,
                FinishCardioMinutes = model.FinishCardioMinutes
            };                       

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> DeleteTrainingAsync(Guid id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.TrainingEntities.Where(x => x.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();

            return id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> EditTrainingAsync(Guid id, string name, string description)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.TrainingEntities
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(x => x
                        .SetProperty(entity => entity.Name, name)
                        .SetProperty(entity => entity.Description, description));

            await context.SaveChangesAsync();

            return id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> EditTrainingCyclesAsync(Guid id, int cycles)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.TrainingEntities
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(x => x
                        .SetProperty(entity => entity.Cycles, cycles));

            await context.SaveChangesAsync();

            return id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> EditTrainingStartCardioMinutesAsync(Guid id, int startCardioMinutes)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.TrainingEntities
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(x => x
                        .SetProperty(entity => entity.StartCardioMinutes, startCardioMinutes));

            await context.SaveChangesAsync();

            return id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> EditTrainingFinishCardioMinutesAsync(Guid id, int finishCardioMinutes)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.TrainingEntities
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(x => x
                        .SetProperty(entity => entity.FinishCardioMinutes, finishCardioMinutes));

            await context.SaveChangesAsync();

            return id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> EditTrainingTotalCountIterationsAsync(Guid id, int totalCountIterations)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.TrainingEntities
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(x => x
                        .SetProperty(entity => entity.TotalCountIterations, totalCountIterations));

            await context.SaveChangesAsync();

            return id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> EditTrainingTotalWeightAsync(Guid id, double totalWeight)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.TrainingEntities
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(x => x
                        .SetProperty(entity => entity.TotalWeight, totalWeight));

            await context.SaveChangesAsync();

            return id;
        }

        /// <inheritdoc/>
        public async Task<Training?> GetTrainingByIdAsync(Guid id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = await context.TrainingEntities
                .Include(x => x.Exercises)!.ThenInclude(x => x.ExerciseTemplate)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
                return null;

            var model = new Training
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Cycles = entity.Cycles,
                StartCardioMinutes = entity.StartCardioMinutes,
                FinishCardioMinutes = entity.FinishCardioMinutes,
                TotalCountIterations = entity.TotalCountIterations,
                TotalWeight = entity.TotalWeight,
                Exercises = []
            };

            if (entity.Exercises is not null)
                model.Exercises = entity.Exercises
                    .Select(x => new Exercise
                    {
                        ExerciseTemplate = new ExerciseTemplate
                        {
                            Id = x.ExerciseTemplate.Id,
                            Name = x.ExerciseTemplate.Name
                        },
                        Id = x.Id,
                        CountIterations = x.CountIterations,
                        Minutes = x.Minutes,
                        Order = x.Order,
                        Weight = x.Weight
                    })
                    .OrderBy(x => x.Order)
                    .ToList();

            return model;
        }

        /// <inheritdoc/>
        public async Task<Training?> GetTrainingByExerciseIdAsync(Guid exerciseId)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var exerciseEntity = await context.ExerciseEntities
                .Include(x => x.Training)
                .FirstOrDefaultAsync(x => x.Id == exerciseId);

            var entity = await context.TrainingEntities
                .Include(x => x.Exercises)!.ThenInclude(x => x.ExerciseTemplate)
                .FirstOrDefaultAsync(x => x.Id == exerciseEntity!.Training.Id);

            if (entity is null)
                return null;

            var model = new Training
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Cycles = entity.Cycles,
                StartCardioMinutes = entity.StartCardioMinutes,
                FinishCardioMinutes = entity.FinishCardioMinutes,
                Exercises = []
            };

            if (entity.Exercises is not null)
                model.Exercises = entity.Exercises
                    .Select(x => new Exercise
                    {
                        ExerciseTemplate = new ExerciseTemplate
                        {
                            Id = x.ExerciseTemplate.Id,
                            Name = x.ExerciseTemplate.Name
                        },
                        Id = x.Id,
                        CountIterations = x.CountIterations,
                        Minutes = x.Minutes,
                        Order = x.Order,
                        Weight = x.Weight
                    })
                    .OrderBy(x => x.Order)
                    .ToList();

            return model;
        }

        /// <inheritdoc/>
        public async Task<List<Training>?> GetTrainingsAsync()
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entities = context.TrainingEntities.AsQueryable();

            if (entities is null)
                return null;

            entities = entities.OrderBy(x => x.Name);

            var filteredEntities = await entities.AsNoTracking().ToListAsync();

            if (filteredEntities is null)
                return null;

            var result = entities
                .Select(x => new Training
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Cycles = x.Cycles,
                    TotalCountIterations = x.TotalCountIterations,
                    TotalWeight = x.TotalWeight
                })
                .ToList();

            return result;
        }
    }
}