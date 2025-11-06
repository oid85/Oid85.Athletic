using Mapster;
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
            var entity = model.Adapt<TrainingEntity>();
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
        public async Task<Guid?> EditTrainingAsync(Training model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            await context.TrainingEntities
                .Where(x => x.Id == model.Id)
                .ExecuteUpdateAsync(x => x
                        .SetProperty(entity => entity.Name, model.Name)
                        .SetProperty(entity => entity.Cycles, model.Cycles));

            await context.SaveChangesAsync();

            return model.Id;
        }

        /// <inheritdoc/>
        public async Task<List<Training>> GetTrainingsAsync()
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var entities = context.TrainingEntities.AsQueryable();

            var filteredEntities = await entities.AsNoTracking().ToListAsync();

            return filteredEntities is null 
                ? [] 
                : entities.Select(x => x.Adapt<Training>()).ToList();
        }
    }
}