using Microsoft.AspNetCore.Mvc;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Core;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;
using Oid85.Athletic.WebHost.Controller.Base;

namespace Oid85.Athletic.WebHost.Controller;

[Route("api/exercise-templates")]
[ApiController]
public class ExerciseTemplateController(
    IAthleticService athleticService)
    : AthleticBaseController
{
    /// <summary>
    /// Получить список шаблонов упражнений
    /// </summary>
    [HttpPost("list")]
    [ProducesResponseType(typeof(BaseResponse<ExerciseTemplateListResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<ExerciseTemplateListResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<ExerciseTemplateListResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetExerciseTemplateListAsync(
        [FromBody] ExerciseTemplateListRequest request) =>
        GetResponseAsync(
            () => athleticService.GetExerciseTemplateListAsync(request),
            result => new BaseResponse<ExerciseTemplateListResponse> { Result = result });

    /// <summary>
    /// Создать шаблон упражнения
    /// </summary>
    [HttpPost("create")]
    [ProducesResponseType(typeof(BaseResponse<CreateExerciseTemplateResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<CreateExerciseTemplateResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<CreateExerciseTemplateResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> CreateExerciseTemplateAsync(
        [FromBody] CreateExerciseTemplateRequest request) =>
        GetResponseAsync(
            () => athleticService.CreateExerciseTemplateAsync(request),
            result => new BaseResponse<CreateExerciseTemplateResponse> { Result = result });

    /// <summary>
    /// Редактировать шаблон упражнения
    /// </summary>
    [HttpPost("edit")]
    [ProducesResponseType(typeof(BaseResponse<EditExerciseTemplateResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<EditExerciseTemplateResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<EditExerciseTemplateResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> EditExerciseTemplateAsync(
        [FromBody] EditExerciseTemplateRequest request) =>
        GetResponseAsync(
            () => athleticService.EditExerciseTemplateAsync(request),
            result => new BaseResponse<EditExerciseTemplateResponse> { Result = result });

    /// <summary>
    /// Удалить шаблон упражнения
    /// </summary>
    [HttpPost("delete")]
    [ProducesResponseType(typeof(BaseResponse<DeleteExerciseTemplateResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<DeleteExerciseTemplateResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<DeleteExerciseTemplateResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> DeleteExerciseTemplateAsync(
        [FromBody] DeleteExerciseTemplateRequest request) =>
        GetResponseAsync(
            () => athleticService.DeleteExerciseTemplateAsync(request),
            result => new BaseResponse<DeleteExerciseTemplateResponse> { Result = result });
}