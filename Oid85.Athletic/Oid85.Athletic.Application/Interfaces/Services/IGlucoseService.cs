
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Interfaces.Services
{
    /// <summary>
    /// Сервис работы с измерениями глюкозы
    /// </summary>
    public interface IGlucoseService
    {
        /// <summary>
        /// Внесение измерения артериального глюкозы
        /// </summary>
        Task<SetGlucoseResponse?> SetGlucoseAsync(SetGlucoseRequest request);

        /// <summary>
        /// Получение списка измерений глюкозы
        /// </summary>
        Task<GetGlucoseListResponse?> GetGlucoseListAsync(GetGlucoseListRequest request);
    }
}
