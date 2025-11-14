
using Oid85.Athletic.Core.Models;

namespace Oid85.Athletic.Application.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий упражнений
    /// </summary>
    public interface IExerciseRepository
    {
        /// <summary>
        /// Создать упражнение
        /// </summary>
        /// <param name="exerciseTemplateId">Идентификатор шаблона упражнения</param>
        /// <param name="trainingId">Идентификатор тренировки</param>        
        Task<Guid?> CreateExerciseAsync(Guid exerciseTemplateId, Guid trainingId);

        /// <summary>
        /// Удалить упражнение
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task<Guid?> DeleteExerciseAsync(Guid id);

        /// <summary>
        /// Редактировать упражнение
        /// </summary>
        /// <param name="model">Модель упражнения</param>
        Task<Guid?> EditExerciseAsync(Exercise model);
    }
}
