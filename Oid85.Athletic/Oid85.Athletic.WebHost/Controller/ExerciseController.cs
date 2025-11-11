using Microsoft.AspNetCore.Mvc;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Core;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;
using Oid85.Athletic.WebHost.Controller.Base;

namespace Oid85.Athletic.WebHost.Controller;

/// <summary>
/// Упражнения
/// </summary>
[Route("api/exercise")]
[ApiController]
public class ExerciseController(
    IExerciseService exerciseService)
    : AthleticBaseController
{
    /// <summary>
    /// Добавить упражнение в тренировку
    /// </summary>
    [HttpPost("create")]
    [ProducesResponseType(typeof(BaseResponse<CreateExerciseResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<CreateExerciseResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<CreateExerciseResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> CreateExerciseAsync(
        [FromBody] CreateExerciseRequest request) =>
        GetResponseAsync(
            () => exerciseService.CreateExerciseAsync(request),
            result => new BaseResponse<CreateExerciseResponse> { Result = result });
}