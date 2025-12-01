
using Oid85.Athletic.Core.Models;

namespace Oid85.Athletic.Application.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий шаблонов упражнений
    /// </summary>
    public interface IExerciseTemplateRepository
    {
        /// <summary>
        /// Создать шаблон упражнения
        /// </summary>
        /// <param name="model">Модель шаблона упражнения</param>
        Task<Guid?> CreateExerciseTemplateAsync(ExerciseTemplate model);
        
        /// <summary>
        /// Удалить шаблон упражнения
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task<Guid?> DeleteExerciseTemplateAsync(Guid id);

        /// <summary>
        /// Редактировать шаблон упражнения
        /// </summary>
        /// <param name="model">Модель шаблона упражнения</param>
        Task<Guid?> EditExerciseTemplateAsync(ExerciseTemplate model);

        /// <summary>
        /// Получить шаблоны упражнений по параметрам
        /// </summary>       
        Task<List<ExerciseTemplate>?> GetExerciseTemplatesAsync();
    }
}
