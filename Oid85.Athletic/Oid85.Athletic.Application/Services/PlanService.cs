using System.Reflection;
using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Common.Helpers;
using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Services
{
    /// <inheritdoc/>
    public class PlanService(
        IPlanRepository planRepository) 
        : IPlanService
    {
        /// <inheritdoc/>
        public async Task<GetPlanListResponse?> GetPlanListAsync(GetPlanListRequest request)
        {
            var planDictionary = DateHelper.GetDates(request.From, request.To).ToDictionary(
                key => key,
                value => new Plan
                {
                    Id = Guid.NewGuid(),
                    Date = value,
                    MorningTraining = null,
                    DayTraining = null
                });

            var plans = await planRepository.GetPlansAsync(request.From, request.To);

            if (plans is not null)
                foreach (var plan in plans)
                    planDictionary[plan.Date] = plan;

            var response = new GetPlanListResponse
            {
                PlanTrainings = planDictionary.Values
                .Select(x =>
                new PlanListItemResponse
                {
                    Id = x.Id,
                    Date = x.Date,
                    MorningTraining = x.MorningTraining is null ? null : 
                        new TrainingItemResponse 
                        { 
                            Id = x.MorningTraining.Id,
                            Name = x.MorningTraining.Name,
                            TotalCountIterations = x.MorningTraining.TotalCountIterations,
                            TotalWeight = x.MorningTraining.TotalWeight
                        },
                    DayTraining = x.DayTraining is null ? null :
                        new TrainingItemResponse
                        {
                            Id = x.DayTraining.Id,
                            Name = x.DayTraining.Name,
                            TotalCountIterations = x.DayTraining.TotalCountIterations,
                            TotalWeight = x.DayTraining.TotalWeight
                        }
                })
                .OrderBy(x => x.Date)
                .ToList(),
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<RemovePlanDayTrainingResponse?> RemovePlanDayTrainingAsync(RemovePlanDayTrainingRequest request)
        {
            if (request.Date < DateOnly.FromDateTime(DateTime.Today))
                return null;

            var id = await planRepository.RemoveDayTrainingAsync(request.Date);

            if (id is null)
                return null;

            var response = new RemovePlanDayTrainingResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<RemovePlanMorningTrainingResponse?> RemovePlanMorningTrainingAsync(RemovePlanMorningTrainingRequest request)
        {
            if (request.Date < DateOnly.FromDateTime(DateTime.Today))
                return null;

            var id = await planRepository.RemoveMorningTrainingAsync(request.Date);

            if (id is null)
                return null;

            var response = new RemovePlanMorningTrainingResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<SetPlanDayTrainingResponse?> SetPlanDayTrainingAsync(SetPlanDayTrainingRequest request)
        {
            if (request.Date < DateOnly.FromDateTime(DateTime.Today))
                return null;

            var id = await planRepository.SetDayTrainingAsync(request.Date, request.TrainingId);

            if (id is null)
                return null;

            var response = new SetPlanDayTrainingResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<SetPlanMorningTrainingResponse?> SetPlanMorningTrainingAsync(SetPlanMorningTrainingRequest request)
        {
            if (request.Date < DateOnly.FromDateTime(DateTime.Today))
                return null;

            var id = await planRepository.SetMorningTrainingAsync(request.Date, request.TrainingId);

            if (id is null)
                return null;

            var response = new SetPlanMorningTrainingResponse
            {
                Id = id.Value
            };

            return response;
        }
    }
}
