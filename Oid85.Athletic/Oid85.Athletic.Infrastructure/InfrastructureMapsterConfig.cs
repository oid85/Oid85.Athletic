using Mapster;
using Oid85.Athletic.Core.Models;
using Oid85.Athletic.Infrastructure.Entities;

namespace Oid85.Athletic.Infrastructure
{
    public class InfrastructureMapsterConfig
    {
        public InfrastructureMapsterConfig()
        {
            TypeAdapterConfig<ExerciseEntity, Exercise>.NewConfig();
            
            TypeAdapterConfig<Exercise, ExerciseEntity>.NewConfig();
            
            TypeAdapterConfig<ExerciseTemplateEntity, ExerciseTemplate>.NewConfig();
            
            TypeAdapterConfig<ExerciseTemplate, ExerciseTemplateEntity>.NewConfig();
            
            TypeAdapterConfig<TrainingEntity, Training>.NewConfig();
            
            TypeAdapterConfig<Training, TrainingEntity>.NewConfig();
            
            TypeAdapterConfig<PlanEntity, Plan>.NewConfig();
            
            TypeAdapterConfig<Plan, PlanEntity>.NewConfig();
        }
    }
}
