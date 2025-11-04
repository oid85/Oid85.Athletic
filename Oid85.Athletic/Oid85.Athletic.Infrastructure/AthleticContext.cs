using Microsoft.EntityFrameworkCore;
using Oid85.Athletic.Common.KnownConstants;
using Oid85.Athletic.Infrastructure.Entities;
using Oid85.Athletic.Infrastructure.Schemas;

namespace Oid85.Athletic.Infrastructure;

public class AthleticContext(DbContextOptions<AthleticContext> options) : DbContext(options)
{
    public DbSet<ExerciseEntity> ExerciseEntities { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .HasDefaultSchema(KnownDatabaseSchemas.Default)
            .ApplyConfigurationsFromAssembly(
                typeof(AthleticContext).Assembly,
                type => type
                    .GetInterface(typeof(IAthleticSchema).ToString()) != null)
            .UseIdentityAlwaysColumns();
    }    
}