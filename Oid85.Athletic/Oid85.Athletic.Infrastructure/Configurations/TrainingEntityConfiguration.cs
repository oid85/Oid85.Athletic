using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oid85.Athletic.Common.KnownConstants;
using Oid85.Athletic.Infrastructure.Entities;

namespace Oid85.Athletic.Infrastructure.Configurations;

internal class TrainingEntityConfiguration : EntityConfigurationBase<TrainingEntity>
{
    public override void Configure(EntityTypeBuilder<TrainingEntity> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("trainings", KnownDatabaseSchemas.Default);
    }
}