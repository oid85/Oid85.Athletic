using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Application.Interfaces.Services;
using Oid85.Athletic.Common.Helpers;
using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Core.Requests;
using Oid85.Athletic.Core.Responses;

namespace Oid85.Athletic.Application.Services
{
    /// <inheritdoc/>
    public class PressureService(
        IPressureRepository pressureRepository)
        : IPressureService
    {
        /// <inheritdoc/>
        public async Task<CreatePressureResponse?> CreatePressureAsync(CreatePressureRequest request)
        {
            var model = new Pressure
            {
                DateTime = DateTime.Now,
                Sys = request.Sys,
                Dia = request.Dia,
                Pulse = request.Pulse
            };

            var id = await pressureRepository.CreatePressureAsync(model);

            if (id is null)
                return null;

            var response = new CreatePressureResponse
            {
                Id = id.Value
            };

            return response;
        }

        /// <inheritdoc/>
        public async Task<GetPressureListResponse?> GetPressureListAsync(GetPressureListRequest request)
        {
            var dates = DateHelper.GetDates(request.From, request.To);
            var pressures = await pressureRepository.GetPressuresAsync(request.From, request.To);

            if (pressures is null)
                return null;    

            var response = new GetPressureListResponse
            {
                DayItems = dates.Select(date => new GetPressureListDayItem 
                { 
                    Date = date, 
                    IntraDayItems = pressures
                    .Where(pressure => pressure.DateTime >= date.ToDateTime(TimeOnly.MinValue) && pressure.DateTime <= date.ToDateTime(TimeOnly.MaxValue))
                    .Select(pressure => new GetPressureListIntraDayItem
                    {
                        Time = TimeOnly.FromDateTime(pressure.DateTime),
                        Dia = pressure.Dia, 
                        Sys = pressure.Sys,
                        Pulse = pressure.Pulse
                    }).ToList()
                }).ToList()
            };

            return response;
        }
    }
}
