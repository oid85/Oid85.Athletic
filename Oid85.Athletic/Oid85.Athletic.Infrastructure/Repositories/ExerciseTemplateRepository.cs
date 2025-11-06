using Mapster;
using Microsoft.EntityFrameworkCore;
using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Infrastructure.Entities;

namespace Oid85.Athletic.Infrastructure.Repositories
{
    /// <inheritdoc/>
    public class ExerciseTemplateRepository(
        IDbContextFactory<AthleticContext> contextFactory) 
        : IExerciseTemplateRepository
    {
        /// <inheritdoc/>
        public async Task<Guid?> CreateExerciseTemplateAsync(ExerciseTemplate model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var entity = model.Adapt<ExerciseTemplateEntity>();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> DeleteExerciseTemplateAsync(Guid id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            await context.ExerciseTemplateEntities.Where(x => x.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();

            return id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> EditExerciseTemplateAsync(ExerciseTemplate model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            await context.ExerciseTemplateEntities
                .Where(x => x.Id == model.Id)
                .ExecuteUpdateAsync(x => x
                        .SetProperty(entity => entity.Name, model.Name)
                        .SetProperty(entity => entity.Muscles, model.Muscles)
                        .SetProperty(entity => entity.Equipment, model.Equipment));

            await context.SaveChangesAsync();

            return model.Id;
        }

        /// <inheritdoc/>
        public async Task<List<ExerciseTemplate>> GetExerciseTemplatesAsync(string? equipment)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var entities = context.ExerciseTemplateEntities.AsQueryable();

            if (!string.IsNullOrEmpty(equipment))
                entities = entities.Where(x => x.Equipment == equipment);

            var filteredEntities = await entities.AsNoTracking().ToListAsync();

            return filteredEntities is null
                ? []
                : entities.Select(x => x.Adapt<ExerciseTemplate>()).ToList();
        }
    }
}
