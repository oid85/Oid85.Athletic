using Microsoft.AspNetCore.Mvc;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Core;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;
using Oid85.Athletic.WebHost.Controller.Base;

namespace Oid85.Athletic.WebHost.Controller;

/// <summary>
/// Тренировки
/// </summary>
[Route("api/trainings")]
[ApiController]
public class TrainingController(
    ITrainingService trainingService)
    : AthleticBaseController
{
    /// <summary>
    /// Получить список тренировок
    /// </summary>
    [HttpPost("list")]
    [ProducesResponseType(typeof(BaseResponse<GetTrainingListResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetTrainingListResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<GetTrainingListResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetTrainingListAsync(
        [FromBody] GetTrainingListRequest request) =>
        GetResponseAsync(
            () => trainingService.GetTrainingListAsync(request),
            result => new BaseResponse<GetTrainingListResponse> { Result = result });

    /// <summary>
    /// Создать тренировку
    /// </summary>
    [HttpPost("create")]
    [ProducesResponseType(typeof(BaseResponse<CreateTrainingResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<CreateTrainingResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<CreateTrainingResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> CreateTrainingAsync(
        [FromBody] CreateTrainingRequest request) =>
        GetResponseAsync(
            () => trainingService.CreateTrainingAsync(request),
            result => new BaseResponse<CreateTrainingResponse> { Result = result });

    /// <summary>
    /// Редактировать наименование тренировки
    /// </summary>
    [HttpPost("edit-name")]
    [ProducesResponseType(typeof(BaseResponse<EditTrainingNameResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<EditTrainingNameResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<EditTrainingNameResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> EditNameTrainingAsync(
        [FromBody] EditTrainingNameRequest request) =>
        GetResponseAsync(
            () => trainingService.EditTrainingNameAsync(request),
            result => new BaseResponse<EditTrainingNameResponse> { Result = result });

    /// <summary>
    /// Удалить тренировку
    /// </summary>
    [HttpPost("delete")]
    [ProducesResponseType(typeof(BaseResponse<DeleteTrainingResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<DeleteTrainingResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<DeleteTrainingResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> DeleteTrainingAsync(
        [FromBody] DeleteTrainingRequest request) =>
        GetResponseAsync(
            () => trainingService.DeleteTrainingAsync(request),
            result => new BaseResponse<DeleteTrainingResponse> { Result = result });

    /// <summary>
    /// Получить тренировку по идентификатору
    /// </summary>
    [HttpPost("get")]
    [ProducesResponseType(typeof(BaseResponse<GetTrainingResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetTrainingResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<GetTrainingResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetTrainingAsync(
        [FromBody] GetTrainingRequest request) =>
        GetResponseAsync(
            () => trainingService.GetTrainingAsync(request),
            result => new BaseResponse<GetTrainingResponse> { Result = result });
}