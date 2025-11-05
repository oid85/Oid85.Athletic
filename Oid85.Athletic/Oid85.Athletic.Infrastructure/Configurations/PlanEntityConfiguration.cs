using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oid85.Athletic.Common.KnownConstants;
using Oid85.Athletic.Infrastructure.Entities;

namespace Oid85.Athletic.Infrastructure.Configurations;

internal class PlanEntityConfiguration : EntityConfigurationBase<PlanEntity>
{
    public override void Configure(EntityTypeBuilder<PlanEntity> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("plans", KnownDatabaseSchemas.Default);

        builder
            .HasOne(x => x.MorningTraining)
            .WithMany()
            .HasForeignKey(x => x.MorningTrainingId);

        builder
            .HasOne(x => x.DayTraining)
            .WithMany()
            .HasForeignKey(x => x.DayTrainingId);
    }
}