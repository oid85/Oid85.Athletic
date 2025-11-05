using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oid85.Athletic.Common.KnownConstants;
using Oid85.Athletic.Infrastructure.Entities;

namespace Oid85.Athletic.Infrastructure.Configurations;

internal class ExerciseEntityConfiguration : EntityConfigurationBase<ExerciseEntity>
{
    public override void Configure(EntityTypeBuilder<ExerciseEntity> builder)
    {
        base.Configure(builder);
    }
}