using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Services
{
    /// <inheritdoc/>
    public class ExerciseService(
        IExerciseRepository exerciseRepository) 
        : IExerciseService
    {
        /// <inheritdoc/>
        public async Task<CreateExerciseResponse?> CreateExerciseAsync(CreateExerciseRequest request)
        {
            var id = await exerciseRepository.CreateExerciseAsync(request.ExerciseTemplateId, request.TrainingId);

            if (id is null) 
                return null;

            var response = new CreateExerciseResponse 
            { 
                Id = id.Value 
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<DeleteExerciseResponse?> DeleteExerciseAsync(DeleteExerciseRequest request)
        {
            var id = await exerciseRepository.DeleteExerciseAsync(request.Id);

            if (id is null)
                return null;

            var response = new DeleteExerciseResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<EditExerciseResponse?> EditExerciseAsync(EditExerciseRequest request)
        {
            var model = new Exercise
            {
                Id = request.Id,
                Order = request.Order,
                CountIterations = request.CountIterations,
                Minutes = request.Minutes,                
                Weight = request.Weight
            };

            var id = await exerciseRepository.EditExerciseAsync(model);

            if (id is null)
                return null;

            var response = new EditExerciseResponse
            {
                Id = id.Value
            };

            return response;
        }
    }
}
