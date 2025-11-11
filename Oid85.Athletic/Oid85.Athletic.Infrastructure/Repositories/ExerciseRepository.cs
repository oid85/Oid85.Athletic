using Microsoft.EntityFrameworkCore;
using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Infrastructure.Entities;

namespace Oid85.Athletic.Infrastructure.Repositories
{
    /// <inheritdoc/>
    public class ExerciseRepository(
        IDbContextFactory<AthleticContext> contextFactory) 
        : IExerciseRepository
    {
        /// <inheritdoc/>
        public async Task<Guid?> CreateExerciseAsync(Guid exerciseTemplateId, Guid trainingId)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var exerciseTemplateEntity = await context.ExerciseTemplateEntities.FirstOrDefaultAsync(x => x.Id == exerciseTemplateId);
            var trainingEntity = await context.TrainingEntities.FirstOrDefaultAsync(x => x.Id == trainingId);

            if (exerciseTemplateEntity is null) return null;
            if (trainingEntity is null) return null;

            var entity = new ExerciseEntity
            { 
                Id = Guid.NewGuid(),
                ExerciseTemplate = exerciseTemplateEntity, 
                Training = trainingEntity 
            };

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
