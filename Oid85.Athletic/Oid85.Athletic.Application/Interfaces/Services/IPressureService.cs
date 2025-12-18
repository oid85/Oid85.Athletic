
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Interfaces.Services
{
    /// <summary>
    /// Сервис работы с измерениями артериального давления
    /// </summary>
    public interface IPressureService
    {
        /// <summary>
        /// Создание измерения артериального давления
        /// </summary>
        Task<CreatePressureResponse?> CreatePressureAsync(CreatePressureRequest request);

        /// <summary>
        /// Получение списка измерений артериального давления
        /// </summary>
        Task<GetPressureListResponse?> GetPressureListAsync(GetPressureListRequest request);
    }
}
