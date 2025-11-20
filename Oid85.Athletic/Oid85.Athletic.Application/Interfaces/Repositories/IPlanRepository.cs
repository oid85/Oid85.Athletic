
using Oid85.Athletic.Core.Models;

namespace Oid85.Athletic.Application.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий планирования
    /// </summary>
    public interface IPlanRepository
    {
        /// <summary>
        /// Получить планы за период
        /// </summary>
        Task<List<Plan>?> GetPlansAsync(DateOnly from, DateOnly to);

        /// <summary>
        /// Установить утреннюю тренировку
        /// </summary>
        Task<Guid?> SetDayTrainingAsync(DateOnly date, Guid trainingId);

        /// <summary>
        /// Установить дневную тренировку
        /// </summary>
        Task<Guid?> SetMorningTrainingAsync(DateOnly date, Guid trainingId);
    }
}
