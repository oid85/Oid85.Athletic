using System.Reflection;
using System.Xml.Linq;
using Mapster;
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
        public async Task<CreateTrainingResponse> CreateTrainingAsync(CreateTrainingRequest request)
        {
            var model = request.Adapt<Training>();
            var id = await trainingRepository.CreateTrainingAsync(model);
            
            return id is null 
                ? new() 
                : new() { Id = id };
        }

        /// <inheritdoc/>
        public async Task<DeleteTrainingResponse> DeleteTrainingAsync(DeleteTrainingRequest request)
        {
            var id = await trainingRepository.DeleteTrainingAsync(request.Id);
            
            return id is null 
                ? new() 
                : new() { Id = id };
        }

        /// <inheritdoc/>
        public async Task<EditTrainingResponse> EditTrainingAsync(EditTrainingRequest request)
        {
            var model = request.Adapt<Training>();
            var id = await trainingRepository.EditTrainingAsync(model);

            return id is null 
                ? new() 
                : new() { Id = id };
        }

        /// <inheritdoc/>
        public async Task<GetTrainingResponse> GetTrainingAsync(GetTrainingRequest request)
        {
            var training = await trainingRepository.GetTrainingByIdAsync(request.Id);

            if (training is null)
                return new();

            var response = new GetTrainingResponse() 
            { 
                Training = new GetTrainingItemResponse
                {
                    Name = training.Name,
                    Cycles = training.Cycles,
                    Exercises = training.Exercises!
                        .Select(x => new ExerciseItemResponse
                        {
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
        public async Task<GetTrainingListResponse> GetTrainingListAsync(GetTrainingListRequest request)
        {
            var trainings = (await trainingRepository.GetTrainingsAsync()).OrderBy(x => x.Name).ToList();

            return trainings is null 
                ? new() 
                : new() { Trainings = trainings.Select(x => x.Adapt<TrainingListItemResponse>()).ToList() };
        }
    }
}
