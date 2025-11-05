using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Infrastructure.Entities;

namespace Oid85.Athletic.Infrastructure.Mapping;

public static class InfrastructureMapper
{
        public static ExerciseEntity Map(Exercise model) =>
        new()
        {
            Id = model.Id
        };
    
    public static Exercise Map(ExerciseEntity entity) =>
        new()
        {
            Id = entity.Id
        };   
}