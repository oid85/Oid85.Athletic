
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Interfaces.Services
{
    /// <summary>
    /// Сервис работы с шаблонами упражнений
    /// </summary>
    public interface IExerciseTemplateService
    {
        /// <summary>
        /// Создание шаблона упражнения
        /// </summary>
        Task<CreateExerciseTemplateResponse?> CreateExerciseTemplateAsync(CreateExerciseTemplateRequest request);

        /// <summary>
        /// Удаление шаблона упражнения
        /// </summary>
        Task<DeleteExerciseTemplateResponse?> DeleteExerciseTemplateAsync(DeleteExerciseTemplateRequest request);

        /// <summary>
        /// Редактирование шаблона упражнения
        /// </summary>
        Task<EditExerciseTemplateResponse?> EditExerciseTemplateAsync(EditExerciseTemplateRequest request);

        /// <summary>
        /// Получение списка шаблонов упражнений
        /// </summary>
        Task<GetExerciseTemplateListResponse?> GetExerciseTemplateListAsync(GetExerciseTemplateListRequest request);
    }
}
