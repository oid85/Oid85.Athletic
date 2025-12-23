using Microsoft.EntityFrameworkCore;
using Oid85.Athletic.Common.KnownConstants;
using Oid85.Athletic.Infrastructure.Entities;
using Oid85.Athletic.Infrastructure.Schemas;

namespace Oid85.Athletic.Infrastructure;

public class AthleticContext(DbContextOptions<AthleticContext> options) : DbContext(options)
{
    public DbSet<ExerciseEntity> ExerciseEntities { get; set; }
    public DbSet<ExerciseTemplateEntity> ExerciseTemplateEntities { get; set; }
    public DbSet<TrainingEntity> TrainingEntities { get; set; }
    public DbSet<PlanEntity> PlanEntities { get; set; }
    public DbSet<PressureEntity> PressureEntities { get; set; }
    public DbSet<GlucoseEntity> GlucoseEntities { get; set; }

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