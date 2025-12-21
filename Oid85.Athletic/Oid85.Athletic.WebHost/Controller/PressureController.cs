using Microsoft.AspNetCore.Mvc;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Application.Services;
using Oid85.Athletic.Core;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;
using Oid85.Athletic.WebHost.Controller.Base;

namespace Oid85.Athletic.WebHost.Controller;

/// <summary>
/// Артериальное давление
/// </summary>
[Route("api/pressure")]
[ApiController]
public class PressureController(
    IPressureService pressureService)
    : BaseController
{
    /// <summary>
    /// Получение списка измерений артериального давления
    /// </summary>
    [HttpPost("list")]
    [ProducesResponseType(typeof(BaseResponse<GetPressureListResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetPressureListResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<GetPressureListResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetPressureListWeekAsync() =>
        GetResponseAsync(
            () => pressureService.GetPressureListAsync(
                new GetPressureListRequest
                {
                    From = DateOnly.FromDateTime(DateTime.Today.AddDays(-14)),
                    To = DateOnly.FromDateTime(DateTime.Today)
                }),
            result => new BaseResponse<GetPressureListResponse> { Result = result });

    /// <summary>
    /// Создать измерение артериального давления
    /// </summary>
    [HttpPost("create")]
    [ProducesResponseType(typeof(BaseResponse<CreatePressureResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<CreatePressureResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<CreatePressureResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> CreatePressureAsync(
        [FromBody] CreatePressureRequest request) =>
        GetResponseAsync(
            () => pressureService.CreatePressureAsync(request),
            result => new BaseResponse<CreatePressureResponse> { Result = result });
}