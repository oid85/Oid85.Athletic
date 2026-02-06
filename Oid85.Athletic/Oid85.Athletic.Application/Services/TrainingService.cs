using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Services
{
    /// <inheritdoc/>
    public class TrainingService(
        ITrainingRepository trainingRepository,
        IPlanRepository planRepository) 
        : ITrainingService
    {
        /// <inheritdoc/>
        public async Task<CreateTrainingResponse?> CreateTrainingAsync(CreateTrainingRequest request)
        {
            var model = new Training
            {
                Name = request.Name,
                Description = request.Description,
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
        public async Task<EditTrainingResponse?> EditTrainingAsync(EditTrainingRequest request)
        {
            var id = await trainingRepository.EditTrainingAsync(request.Id, request.Name, request.Description);

            var response = new EditTrainingResponse
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

            var intensity = await GetTrainingIntensityAsync(training!.Id);
            if (intensity.TotalCountIterations.HasValue) await trainingRepository.EditTrainingTotalCountIterationsAsync(training.Id, intensity.TotalCountIterations.Value);
            if (intensity.TotalWeight.HasValue) await trainingRepository.EditTrainingTotalWeightAsync(training.Id, intensity.TotalWeight.Value);

            var response = new GetTrainingResponse() 
            { 
                Training = new GetTrainingItemResponse
                {
                    Id = training.Id,
                    Name = training.Name,
                    Description = training.Description,
                    Cycles = training.Cycles,
                    StartCardioMinutes = training.StartCardioMinutes,
                    FinishCardioMinutes = training.FinishCardioMinutes,
                    TotalCountIterations = training.TotalCountIterations,
                    TotalWeight = training.TotalWeight,
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
            var plans = (await planRepository.GetAllPlansAsync())!.Where(x => x.DayTraining is not null).ToList();

            if (trainings is null)
                return null;           

            var response = new GetTrainingListResponse
            {
                Trainings = trainings
                .Select(x =>
                new TrainingListItemResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = plans.Count(p => p.DayTraining!.Id == x.Id),
                    Description = x.Description,
                    TotalCountIterations = x.TotalCountIterations,
                    TotalWeight = x.TotalWeight
                })
                .OrderBy(x => x.TotalWeight) 
                .ToList(),
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<(int? TotalCountIterations, double? TotalWeight)> GetTrainingIntensityAsync(Guid id)
        {
            var training = await trainingRepository.GetTrainingByIdAsync(id);

            if (training is null)
                return new();

            var totalCountIterations = training.Exercises!.Sum(x => x.CountIterations) * training.Cycles;
            var totalWeight = training.Exercises!.Sum(x => x.Weight * x.CountIterations) * training.Cycles;

            return (totalCountIterations, totalWeight);
        }
    }
}
