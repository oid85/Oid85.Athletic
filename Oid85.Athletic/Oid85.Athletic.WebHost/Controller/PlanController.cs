using Microsoft.AspNetCore.Mvc;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Core;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;
using Oid85.Athletic.WebHost.Controller.Base;

namespace Oid85.Athletic.WebHost.Controller;

/// <summary>
/// Планирование
/// </summary>
[Route("api/plans")]
[ApiController]
public class PlanController(
    IPlanService planService)
    : BaseController
{
    /// <summary>
    /// Запланированные тренировки
    /// </summary>
    [HttpPost("list/week")]
    [ProducesResponseType(typeof(BaseResponse<GetPlanListResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetPlanListResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<GetPlanListResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetPlanListAsync() =>
        GetResponseAsync(
            () => planService.GetPlanListAsync(
                new GetPlanListRequest
                {
                    From = DateOnly.FromDateTime(DateTime.Today.AddDays(-4)),
                    To = DateOnly.FromDateTime(DateTime.Today.AddDays(2))
                }),
            result => new BaseResponse<GetPlanListResponse> { Result = result });
}