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
        public async Task<CreateExerciseTemplateResponse?> CreateExerciseTemplateAsync(CreateExerciseTemplateRequest request)
        {
            var model = new ExerciseTemplate
            {
                Name = request.Name,
                Equipment = request.Equipment,
                Muscles = request.Muscles
            };

            var id = await exerciseTemplateRepository.CreateExerciseTemplateAsync(model);

            if (id is null)
                return null;

            var response = new CreateExerciseTemplateResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<DeleteExerciseTemplateResponse?> DeleteExerciseTemplateAsync(DeleteExerciseTemplateRequest request)
        {
            var id = await exerciseTemplateRepository.DeleteExerciseTemplateAsync(request.Id);

            if (id is null)
                return null;

            var response = new DeleteExerciseTemplateResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<EditExerciseTemplateResponse?> EditExerciseTemplateAsync(EditExerciseTemplateRequest request)
        {
            var model = new ExerciseTemplate
            {
                Id = request.Id,
                Name = request.Name,
                Equipment = request.Equipment,
                Muscles = request.Muscles
            };

            var id = await exerciseTemplateRepository.EditExerciseTemplateAsync(model);

            if (id is null)
                return null;

            var response = new EditExerciseTemplateResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<GetExerciseTemplateListResponse?> GetExerciseTemplateListAsync(GetExerciseTemplateListRequest request)
        {
            var exerciseTemplates = await exerciseTemplateRepository.GetExerciseTemplatesAsync(request.Equipment);

            if (exerciseTemplates is null)
                return null;

            var response = new GetExerciseTemplateListResponse
            {
                ExerciseTemplates = exerciseTemplates
                    .Select(x => new ExerciseTemplateListItemResponse
                    {
                        Name = x.Name,
                        Equipment = x.Equipment,
                        Muscles = x.Muscles
                    }).ToList()
            };

            return response;
        }
    }
}
