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
    /// Редактировать тренировку
    /// </summary>
    [HttpPost("edit")]
    [ProducesResponseType(typeof(BaseResponse<EditTrainingResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<EditTrainingResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<EditTrainingResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> EditTrainingAsync(
        [FromBody] EditTrainingRequest request) =>
        GetResponseAsync(
            () => trainingService.EditTrainingAsync(request),
            result => new BaseResponse<EditTrainingResponse> { Result = result });

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
}