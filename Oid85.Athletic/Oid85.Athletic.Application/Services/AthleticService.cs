using System.Reflection;
using Mapster;
using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Services
{
    /// <inheritdoc/>
    public class AthleticService(
        IExerciseTemplateRepository exerciseTemplateRepository) 
        : IAthleticService
    {
        /// <inheritdoc/>
        public async Task<CreateExerciseTemplateResponse> CreateExerciseTemplateAsync(CreateExerciseTemplateRequest request)
        {
            var model = request.Adapt<ExerciseTemplate>();
            var id = await exerciseTemplateRepository.CreateExerciseTemplateAsync(model);

            if (id is null)
                return new();

            return new() { Id = id };
        }

        /// <inheritdoc/>
        public async Task<DeleteExerciseTemplateResponse> DeleteExerciseTemplateAsync(DeleteExerciseTemplateRequest request)
        {
            var id = await exerciseTemplateRepository.DeleteExerciseTemplateAsync(request.Id);

            if (id is null)
                return new();

            return new() { Id = id };
        }

        /// <inheritdoc/>
        public async Task<EditExerciseTemplateResponse> EditExerciseTemplateAsync(EditExerciseTemplateRequest request)
        {
            var model = request.Adapt<ExerciseTemplate>();
            var id = await exerciseTemplateRepository.EditExerciseTemplateAsync(model);

            if (id is null)
                return new();

            return new() { Id = id };
        }

        /// <inheritdoc/>
        public async Task<ExerciseTemplateListResponse> GetExerciseTemplateListAsync(ExerciseTemplateListRequest request)
        {
            var exerciseTemplates = await exerciseTemplateRepository
                .GetExerciseTemplatesAsync(request.Equipment);

            if (exerciseTemplates is null)
                return new();

            return new()
            {
                ExerciseTemplates = exerciseTemplates.Select(x => x.Adapt<ExerciseTemplateListItem>()).ToList()
            };
        }
    }
}
