using Microsoft.EntityFrameworkCore;
using Oid85.Athletic.Application.Interfaces.Repositories;
using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Infrastructure.Entities;

namespace Oid85.Athletic.Infrastructure.Repositories
{
    /// <inheritdoc/>
    public class PressureRepository(
        IDbContextFactory<AthleticContext> contextFactory) 
        : IPressureRepository
    {
        /// <inheritdoc/>
        public async Task<Guid?> CreatePressureAsync(Pressure model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = new PressureEntity
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                Sys = model.Sys,
                Dia = model.Dia,
                Pulse = model.Pulse
            };

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc/>
        public async Task<List<Pressure>?> GetPressuresAsync(DateOnly from, DateOnly to)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entities = context.PressureEntities
                .Where(x => x.DateTime >= from.ToDateTime(TimeOnly.MinValue))
                .Where(x => x.DateTime <= to.ToDateTime(TimeOnly.MinValue))
                .AsQueryable();

            if (entities is null)
                return null;

            entities = entities.OrderBy(x => x.DateTime);

            var filteredEntities = await entities.AsNoTracking().ToListAsync();

            if (filteredEntities is null)
                return null;

            var result = entities
                .Select(x => new Pressure
                {
                    Id = x.Id,
                    DateTime = x.DateTime,
                    Sys = x.Sys,
                    Dia = x.Dia,
                    Pulse = x.Pulse
                })
                .ToList();

            return result;
        }
    }
}
