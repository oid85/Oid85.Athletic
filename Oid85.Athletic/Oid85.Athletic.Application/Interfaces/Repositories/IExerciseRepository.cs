
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
    }
}
