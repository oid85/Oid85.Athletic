using Oid85.Athletic.Core.Models;

namespace Oid85.Athletic.Application.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий тренировок
    /// </summary>
    public interface ITrainingRepository
    {
        /// <summary>
        /// Создать тренировку
        /// </summary>
        /// <param name="model">Модель тренировки</param>
        Task<Guid?> CreateTrainingAsync(Training model);

        /// <summary>
        /// Удалить тренировку
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task<Guid?> DeleteTrainingAsync(Guid id);

        /// <summary>
        /// Редактировать тренировку
        /// </summary>
        /// <param name="model">Модель тренировки</param>
        Task<Guid?> EditTrainingAsync(Training model);

        /// <summary>
        /// Получить тренировку
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task<Training?> GetTrainingByIdAsync(Guid id);

        /// <summary>
        /// Получить список тренировок
        /// </summary>    
        Task<List<Training>?> GetTrainingsAsync();
    }
}
