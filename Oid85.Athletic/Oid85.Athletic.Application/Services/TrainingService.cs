using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Services
{
    /// <inheritdoc/>
    public class TrainingService(
        ITrainingRepository trainingRepository) 
        : ITrainingService
    {
        /// <inheritdoc/>
        public async Task<CreateTrainingResponse?> CreateTrainingAsync(CreateTrainingRequest request)
        {
            var model = new Training
            {
                Name = request.Name
            };

            var id = await trainingRepository.CreateTrainingAsync(model);

            if (id is null)
                return null;

            var response = new CreateTrainingResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<DeleteTrainingResponse?> DeleteTrainingAsync(DeleteTrainingRequest request)
        {
            var id = await trainingRepository.DeleteTrainingAsync(request.Id);

            var response = new DeleteTrainingResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<EditTrainingResponse?> EditTrainingAsync(EditTrainingRequest request)
        {
            var model = new Training
            {
                Id = request.Id,
                Name = request.Name,
                Cycles = request.Cycles
            };

            var id = await trainingRepository.EditTrainingAsync(model);

            var response = new EditTrainingResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<GetTrainingResponse?> GetTrainingAsync(GetTrainingRequest request)
        {
            var training = await trainingRepository.GetTrainingByIdAsync(request.Id);

            if (training is null)
                return new();

            var response = new GetTrainingResponse() 
            { 
                Training = new GetTrainingItemResponse
                {
                    Id = training.Id,
                    Name = training.Name,
                    Cycles = training.Cycles,
                    Exercises = training.Exercises!
                        .Select(x => new ExerciseItemResponse
                        {
                            Id = x.Id,
                            Name = x.ExerciseTemplate.Name,
                            CountIterations = x.CountIterations,
                            Minutes = x.Minutes,
                            Order = x.Order,
                            Weight = x.Weight
                        })
                        .ToList()
                }
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<GetTrainingListResponse?> GetTrainingListAsync(GetTrainingListRequest request)
        {
            var trainings = await trainingRepository.GetTrainingsAsync();

            if (trainings is null)
                return null;

            var response = new GetTrainingListResponse()
            {
                Trainings = trainings
                    .Select(x => new TrainingListItemResponse
                    {
                        Id = x.Id,
                        Name = x.Name
                    })
                    .ToList()
            };

            return response;
        }
    }
}
