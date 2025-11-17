using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Services
{
    /// <inheritdoc/>
    public class ExerciseService(
        IExerciseRepository exerciseRepository,
        ITrainingRepository trainingRepository,
        ITrainingService trainingService) 
        : IExerciseService
    {
        /// <inheritdoc/>
        public async Task<CreateExerciseResponse?> CreateExerciseAsync(CreateExerciseRequest request)
        {
            var id = await exerciseRepository.CreateExerciseAsync(request.ExerciseTemplateId, request.TrainingId);            
            
            var intensity = await trainingService.GetTrainingIntensityAsync(request.TrainingId);
            if (intensity.TotalCountIterations.HasValue) await trainingRepository.EditTrainingTotalCountIterationsAsync(request.TrainingId, intensity.TotalCountIterations.Value);
            if (intensity.TotalWeight.HasValue) await trainingRepository.EditTrainingTotalWeightAsync(request.TrainingId, intensity.TotalWeight.Value);

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

            var training = await trainingRepository.GetTrainingByExerciseIdAsync(request.Id);
            var intensity = await trainingService.GetTrainingIntensityAsync(training!.Id);
            if (intensity.TotalCountIterations.HasValue) await trainingRepository.EditTrainingTotalCountIterationsAsync(training.Id, intensity.TotalCountIterations.Value);
            if (intensity.TotalWeight.HasValue) await trainingRepository.EditTrainingTotalWeightAsync(training.Id, intensity.TotalWeight.Value);

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

            var training = await trainingRepository.GetTrainingByExerciseIdAsync(request.Id);
            var intensity = await trainingService.GetTrainingIntensityAsync(training!.Id);
            if (intensity.TotalCountIterations.HasValue) await trainingRepository.EditTrainingTotalCountIterationsAsync(training.Id, intensity.TotalCountIterations.Value);
            if (intensity.TotalWeight.HasValue) await trainingRepository.EditTrainingTotalWeightAsync(training.Id, intensity.TotalWeight.Value);

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
