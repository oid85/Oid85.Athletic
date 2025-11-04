
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Interfaces.Services
{
    public interface IAthleticService
    {
        Task<ExerciseListResponse> GetExerciseListAsync(ExerciseListRequest request);
    }
}
