using Microsoft.EntityFrameworkCore;
using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Core.Models;
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
            var trainingEntity = await context.TrainingEntities.Include(x => x.Exercises).FirstOrDefaultAsync(x => x.Id == trainingId);
            var exerciseCount = await context.ExerciseEntities.Include(x => x.Training).CountAsync(x => x.Training.Id == trainingId);

            if (exerciseTemplateEntity is null) return null;
            if (trainingEntity is null) return null;

            var entity = new ExerciseEntity
            { 
                Id = Guid.NewGuid(),
                ExerciseTemplate = exerciseTemplateEntity, 
                Training = trainingEntity,
                Order = exerciseCount + 1
            };            

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Guid?> DeleteExerciseAsync(Guid id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.ExerciseEntities.Where(x => x.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();

            return id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> EditExerciseAsync(Exercise model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.ExerciseEntities
                .Where(x => x.Id == model.Id)
                .ExecuteUpdateAsync(x => x
                        .SetProperty(entity => entity.Order, model.Order == 0 ? 1 : model.Order)
                        .SetProperty(entity => entity.CountIterations, model.CountIterations == 0 ? null : model.CountIterations)
                        .SetProperty(entity => entity.Minutes, model.Minutes == 0 ? null : model.Minutes)                        
                        .SetProperty(entity => entity.Weight, model.Weight == 0 ? null : model.Weight));

            await context.SaveChangesAsync();

            return model.Id;
        }
    }
}
