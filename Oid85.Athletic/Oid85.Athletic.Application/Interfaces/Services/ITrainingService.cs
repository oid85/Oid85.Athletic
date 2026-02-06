
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
        Task<CreateTrainingResponse?> CreateTrainingAsync(CreateTrainingRequest request);

        /// <summary>
        /// Удаление тренировки
        /// </summary>
        Task<DeleteTrainingResponse?> DeleteTrainingAsync(DeleteTrainingRequest request);

        /// <summary>
        /// Редактирование наименования тренировки
        /// </summary>
        Task<EditTrainingResponse?> EditTrainingAsync(EditTrainingRequest request);

        /// <summary>
        /// Редактировать количество циклов в тренировке
        /// </summary>
        Task<EditTrainingCyclesResponse?> EditTrainingCyclesAsync(EditTrainingCyclesRequest request);

        /// <summary>
        /// Редактировать длительность разминочного кардио
        /// </summary>
        Task<EditTrainingStartCardioMinutesResponse?> EditTrainingStartCardioMinutesAsync(EditTrainingStartCardioMinutesRequest request);

        /// <summary>
        /// Редактировать длительность заминочного кардио
        /// </summary>
        Task<EditTrainingFinishCardioMinutesResponse?> EditTrainingFinishCardioMinutesAsync(EditTrainingFinishCardioMinutesRequest request);

        /// <summary>
        /// Получение списка тренировок
        /// </summary>
        Task<GetTrainingListResponse?> GetTrainingListAsync(GetTrainingListRequest request);

        /// <summary>
        /// Получение тренировки по идентификатору
        /// </summary>
        Task<GetTrainingResponse?> GetTrainingAsync(GetTrainingRequest request);

        /// <summary>
        /// Расчитать интенсивность тренировки (общее кол-во повторений, общий вес)
        /// </summary>
        /// <param name="id">Идентификатор тренировки</param>
        Task<(int? TotalCountIterations, double? TotalWeight)> GetTrainingIntensityAsync(Guid id);
    }
}
