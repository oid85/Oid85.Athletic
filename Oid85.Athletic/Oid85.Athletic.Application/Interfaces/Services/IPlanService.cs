
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Interfaces.Services
{
    /// <summary>
    /// Сервис планирования
    /// </summary>
    public interface IPlanService
    {
        /// <summary>
        /// Получить список запланированных тренировок
        /// </summary>
        Task<GetPlanListResponse?> GetPlanListAsync(GetPlanListRequest request);

        /// <summary>
        /// Запланировать утреннюю тренировку
        /// </summary>
        Task<SetPlanMorningTrainingResponse?> SetPlanMorningTrainingAsync(SetPlanMorningTrainingRequest request);

        /// <summary>
        /// Запланировать дневную тренировку
        /// </summary>
        Task<SetPlanDayTrainingResponse?> SetPlanDayTrainingAsync(SetPlanDayTrainingRequest request);

        /// <summary>
        /// Удалить утреннюю тренировку
        /// </summary>
        Task<RemovePlanMorningTrainingResponse?> RemovePlanMorningTrainingAsync(RemovePlanMorningTrainingRequest request);

        /// <summary>
        /// Удалить дневную тренировку
        /// </summary>
        Task<RemovePlanDayTrainingResponse?> RemovePlanDayTrainingAsync(RemovePlanDayTrainingRequest request);
    }
}
