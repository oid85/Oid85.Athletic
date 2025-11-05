using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oid85.Athletic.Common.KnownConstants;
using Oid85.Athletic.Infrastructure.Entities;

namespace Oid85.Athletic.Infrastructure.Configurations;

internal class ExerciseTemplateEntityConfiguration : EntityConfigurationBase<ExerciseTemplateEntity>
{
    public override void Configure(EntityTypeBuilder<ExerciseTemplateEntity> builder)
    {
        base.Configure(builder);
    }
}