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
        /// Редактировать наименование тренировки
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="name">Наименование</param>
        Task<Guid?> EditTrainingNameAsync(Guid id, string name);

        /// <summary>
        /// Редактировать количество циклов в тренировке
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cycles">Количество циклов</param>
        Task<Guid?> EditTrainingCyclesAsync(Guid id, int cycles);

        /// <summary>
        /// Редактировать длительность разминочного кардио
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="startCardioMinutes">Длительность разминочного кардио</param>
        Task<Guid?> EditTrainingStartCardioMinutesAsync(Guid id, int startCardioMinutes);

        /// <summary>
        /// Редактировать длительность заминочного кардио
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="finishCardioMinutes">Длительность заминочного кардио</param>
        Task<Guid?> EditTrainingFinishCardioMinutesAsync(Guid id, int finishCardioMinutes);

        /// <summary>
        /// Редактировать общее кол-во повторений
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="totalCountIterations">Общее кол-во повторений</param>
        Task<Guid?> EditTrainingTotalCountIterationsAsync(Guid id, int totalCountIterations);

        /// <summary>
        /// Редактировать общий вес
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="totalWeight">Общий вес</param>
        Task<Guid?> EditTrainingTotalWeightAsync(Guid id, double totalWeight);

        /// <summary>
        /// Получить тренировку по Id
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task<Training?> GetTrainingByIdAsync(Guid id);

        /// <summary>
        /// Получить тренировку по Id упражнения
        /// </summary>
        /// <param name="id">Идентификатор</param>
        Task<Training?> GetTrainingByExerciseIdAsync(Guid exerciseId);

        /// <summary>
        /// Получить список тренировок
        /// </summary>    
        Task<List<Training>?> GetTrainingsAsync();
    }
}
