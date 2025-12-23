using Microsoft.AspNetCore.Mvc;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Core;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;
using Oid85.Athletic.WebHost.Controller.Base;

namespace Oid85.Athletic.WebHost.Controller;

/// <summary>
/// Глюкоза
/// </summary>
[Route("api/glucose")]
[ApiController]
public class GlucoseController(
    IGlucoseService glucoseService)
    : BaseController
{
    /// <summary>
    /// Получение списка измерений глюкозы
    /// </summary>
    [HttpPost("list")]
    [ProducesResponseType(typeof(BaseResponse<GetGlucoseListResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetGlucoseListResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<GetGlucoseListResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetGlucoseListAsync() =>
        GetResponseAsync(
            () => glucoseService.GetGlucoseListAsync(
                new GetGlucoseListRequest
                {
                    From = DateOnly.FromDateTime(DateTime.Today.AddDays(-14)),
                    To = DateOnly.FromDateTime(DateTime.Today)
                }),
            result => new BaseResponse<GetGlucoseListResponse> { Result = result });

    /// <summary>
    /// Внести измерение глюкозы
    /// </summary>
    [HttpPost("set")]
    [ProducesResponseType(typeof(BaseResponse<SetGlucoseResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<SetGlucoseResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<SetGlucoseResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> SetGlucoseAsync(
        [FromBody] SetGlucoseRequest request) =>
        GetResponseAsync(
            () => glucoseService.SetGlucoseAsync(request),
            result => new BaseResponse<SetGlucoseResponse> { Result = result });
}