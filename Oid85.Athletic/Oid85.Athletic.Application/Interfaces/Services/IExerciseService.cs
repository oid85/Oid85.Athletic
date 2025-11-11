
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Interfaces.Services
{
    /// <summary>
    /// Сервис работы с упражнений
    /// </summary>
    public interface IExerciseService
    {
        /// <summary>
        /// Создание упражнения
        /// </summary>
        Task<CreateExerciseResponse> CreateExerciseAsync(CreateExerciseRequest request);
    }
}
