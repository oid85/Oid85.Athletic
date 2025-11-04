using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Services
{
    public class TrainingService : ITrainingService
    {
        public Task<ExerciseListResponse> GetExerciseListAsync(ExerciseListRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
