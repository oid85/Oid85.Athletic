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
    public class ExerciseTemplateService(
        IExerciseTemplateRepository exerciseTemplateRepository) 
        : IExerciseTemplateService
    {
        /// <inheritdoc/>
        public async Task<CreateExerciseTemplateResponse> CreateExerciseTemplateAsync(CreateExerciseTemplateRequest request)
        {
            var model = request.Adapt<ExerciseTemplate>();
            var id = await exerciseTemplateRepository.CreateExerciseTemplateAsync(model);

            return id is null ? new() : new() { Id = id };
        }

        /// <inheritdoc/>
        public async Task<DeleteExerciseTemplateResponse> DeleteExerciseTemplateAsync(DeleteExerciseTemplateRequest request)
        {
            var id = await exerciseTemplateRepository.DeleteExerciseTemplateAsync(request.Id);

            return id is null ? new() : new() { Id = id };
        }

        /// <inheritdoc/>
        public async Task<EditExerciseTemplateResponse> EditExerciseTemplateAsync(EditExerciseTemplateRequest request)
        {
            var model = request.Adapt<ExerciseTemplate>();
            var id = await exerciseTemplateRepository.EditExerciseTemplateAsync(model);

            return id is null ? new() : new() { Id = id };
        }

        /// <inheritdoc/>
        public async Task<GetExerciseTemplateListResponse> GetExerciseTemplateListAsync(GetExerciseTemplateListRequest request)
        {
            var exerciseTemplates = (await exerciseTemplateRepository.GetExerciseTemplatesAsync(request.Equipment)).OrderBy(x => x.Name).ToList();

            return exerciseTemplates is null 
                ? new() : new() { ExerciseTemplates = exerciseTemplates.Select(x => x.Adapt<ExerciseTemplateListItemResponse>()).ToList() };
        }
    }
}
