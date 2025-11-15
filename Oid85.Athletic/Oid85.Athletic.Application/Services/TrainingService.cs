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
                Name = request.Name,
                Cycles = 1,
                StartCardioMinutes = 5,
                FinishCardioMinutes = 5
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
        public async Task<EditTrainingNameResponse?> EditTrainingNameAsync(EditTrainingNameRequest request)
        {
            var id = await trainingRepository.EditTrainingNameAsync(request.Id, request.Name);

            var response = new EditTrainingNameResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<EditTrainingCyclesResponse?> EditTrainingCyclesAsync(EditTrainingCyclesRequest request)
        {
            var id = await trainingRepository.EditTrainingCyclesAsync(request.Id, request.Cycles);

            var response = new EditTrainingCyclesResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<EditTrainingStartCardioMinutesResponse?> EditTrainingStartCardioMinutesAsync(EditTrainingStartCardioMinutesRequest request)
        {
            var id = await trainingRepository.EditTrainingStartCardioMinutesAsync(request.Id, request.StartCardioMinutes);

            var response = new EditTrainingStartCardioMinutesResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<EditTrainingFinishCardioMinutesResponse?> EditTrainingFinishCardioMinutesAsync(EditTrainingFinishCardioMinutesRequest request)
        {
            var id = await trainingRepository.EditTrainingFinishCardioMinutesAsync(request.Id, request.FinishCardioMinutes);

            var response = new EditTrainingFinishCardioMinutesResponse
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
                    StartCardioMinutes = training.StartCardioMinutes,
                    FinishCardioMinutes = training.FinishCardioMinutes,
                    TotalCountIterations = training.Exercises!.Sum(x => x.CountIterations) * training.Cycles,
                    TotalWeight = training.Exercises!.Sum(x => x.Weight) * training.Cycles,
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
            
            var trainingListItems = new List<TrainingListItemResponse>();

            foreach (var item in trainings)
            {
                var training = await trainingRepository.GetTrainingByIdAsync(item.Id);

                trainingListItems.Add(
                    new TrainingListItemResponse
                    {
                        Id = training!.Id,
                        Name = training.Name,
                        TotalCountIterations = training.Exercises!.Sum(x => x.CountIterations) * training.Cycles,
                        TotalWeight = training.Exercises!.Sum(x => x.Weight) * training.Cycles
                    });
            }

            var response = new GetTrainingListResponse
            {
                Trainings = trainingListItems.OrderBy(x => x.TotalCountIterations).ToList(),
            };

            return response;
        }
    }
}
