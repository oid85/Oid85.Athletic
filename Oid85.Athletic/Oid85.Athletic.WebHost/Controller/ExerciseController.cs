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

    /// <summary>
    /// Редактировать упражнение в тренировке
    /// </summary>
    [HttpPost("edit")]
    [ProducesResponseType(typeof(BaseResponse<EditExerciseResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<EditExerciseResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<EditExerciseResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> EditExerciseAsync(
        [FromBody] EditExerciseRequest request) =>
        GetResponseAsync(
            () => exerciseService.EditExerciseAsync(request),
            result => new BaseResponse<EditExerciseResponse> { Result = result });

    /// <summary>
    /// Удалить упражнение из тренировки
    /// </summary>
    [HttpPost("delete")]
    [ProducesResponseType(typeof(BaseResponse<DeleteExerciseResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<DeleteExerciseResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<DeleteExerciseResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> DeleteExerciseAsync(
        [FromBody] DeleteExerciseRequest request) =>
        GetResponseAsync(
            () => exerciseService.DeleteExerciseAsync(request),
            result => new BaseResponse<DeleteExerciseResponse> { Result = result });
}