
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Interfaces.Services
{
    /// <summary>
    /// Сервис работы с тренировками
    /// </summary>
    public interface ITrainingService
    {
        /// <summary>
        /// Создание тренировки
        /// </summary>
        Task<CreateTrainingResponse> CreateTrainingAsync(CreateTrainingRequest request);

        /// <summary>
        /// Удаление тренировки
        /// </summary>
        Task<DeleteTrainingResponse> DeleteTrainingAsync(DeleteTrainingRequest request);

        /// <summary>
        /// Редактирование тренировку
        /// </summary>
        Task<EditTrainingResponse> EditTrainingAsync(EditTrainingRequest request);

        /// <summary>
        /// Получение списка тренировок
        /// </summary>
        Task<GetTrainingListResponse> GetTrainingListAsync(GetTrainingListRequest request);

        /// <summary>
        /// Получение тренировки по идентификатору
        /// </summary>
        Task<GetTrainingResponse> GetTrainingAsync(GetTrainingRequest request);
    }
}
