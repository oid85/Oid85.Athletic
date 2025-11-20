
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
    }
}
