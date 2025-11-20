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
    /// Недельный план тренировок
    /// </summary>
    [HttpPost("list/week")]
    [ProducesResponseType(typeof(BaseResponse<GetPlanListResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetPlanListResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<GetPlanListResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> GetPlanListWeekAsync() =>
        GetResponseAsync(
            () => planService.GetPlanListAsync(
                new GetPlanListRequest
                {
                    From = DateOnly.FromDateTime(DateTime.Today.AddDays(-4)),
                    To = DateOnly.FromDateTime(DateTime.Today.AddDays(2))
                }),
            result => new BaseResponse<GetPlanListResponse> { Result = result });

    /// <summary>
    /// Запланировать утреннюю тренировку
    /// </summary>
    [HttpPost("set/morning")]
    [ProducesResponseType(typeof(BaseResponse<SetPlanMorningTrainingResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<SetPlanMorningTrainingResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<SetPlanMorningTrainingResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> SetPlanMorningTrainingAsync(
        [FromBody] SetPlanMorningTrainingRequest request) =>
        GetResponseAsync(
            () => planService.SetPlanMorningTrainingAsync(request),
            result => new BaseResponse<SetPlanMorningTrainingResponse> { Result = result });

    /// <summary>
    /// Запланировать дневную тренировку
    /// </summary>
    [HttpPost("set/day")]
    [ProducesResponseType(typeof(BaseResponse<SetPlanDayTrainingResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<SetPlanDayTrainingResponse>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<SetPlanDayTrainingResponse>), StatusCodes.Status500InternalServerError)]
    public Task<IActionResult> SetPlanDayTrainingAsync(
        [FromBody] SetPlanDayTrainingRequest request) =>
        GetResponseAsync(
            () => planService.SetPlanDayTrainingAsync(request),
            result => new BaseResponse<SetPlanDayTrainingResponse> { Result = result });
}