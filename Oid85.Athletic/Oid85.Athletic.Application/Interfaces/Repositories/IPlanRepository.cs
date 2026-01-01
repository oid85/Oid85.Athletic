
using Oid85.Athletic.Core.Models;

namespace Oid85.Athletic.Application.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий планирования
    /// </summary>
    public interface IPlanRepository
    {
        /// <summary>
        /// Получить план по идентификатору
        /// </summary>
        Task<Plan?> GetPlanByIdAsync(Guid planId);

        /// <summary>
        /// Получить планы за период
        /// </summary>
        Task<List<Plan>?> GetPlansAsync(DateOnly from, DateOnly to);

        /// <summary>
        /// Удалить тренировку
        /// </summary>
        Task<Guid?> RemoveTrainingAsync(Guid planId, Guid trainingId);

        /// <summary>
        /// Установить дневную тренировку
        /// </summary>
        Task<Guid?> SetDayTrainingAsync(DateOnly date, Guid trainingId);
    }
}
