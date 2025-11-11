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
    public class ExerciseService(
        IExerciseRepository exerciseRepository) 
        : IExerciseService
    {
        /// <inheritdoc/>
        public async Task<CreateExerciseResponse> CreateExerciseAsync(CreateExerciseRequest request)
        {
            var id = await exerciseRepository.CreateExerciseAsync(request.ExerciseTemplateId, request.TrainingId);

            return id is null ? new() : new() { Id = id };
        }
    }
}
