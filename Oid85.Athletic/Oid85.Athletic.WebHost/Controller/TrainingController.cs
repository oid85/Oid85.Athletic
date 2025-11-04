using Microsoft.AspNetCore.Mvc;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Core;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;
using Oid85.Athletic.WebHost.Controller.Base;

namespace Oid85.Athletic.WebHost.Controller;

[Route("api/training")]
[ApiController]
public class TrainingController(
    IAthleticService trainingService
    )
    : AthleticBaseController
{
    /// <summary>
    /// Получить список упражнений
    /// </summary>
    [HttpPost("exercise-list")]
    [ProducesResponseType(typeof(BaseResponse<ExerciseListResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<ExerciseListResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<ExerciseListResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetExerciseListAsync(
        [FromBody] ExerciseListRequest request) =>
        GetResponseAsync(
            () => trainingService.GetExerciseListAsync(request),
            result => new BaseResponse<ExerciseListResponse>
            {
                Result = result
            });
}