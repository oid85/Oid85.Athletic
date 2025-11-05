using System.ComponentModel.DataAnnotations.Schema;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    public class ExerciseEntity : BaseEntity
    {
        public int CountIterations { get; set; }

        public int Order { get; set; }

        public ExerciseTemplateEntity ExerciseTemplate { get; set; }

        public TrainingEntity Training { get; set; }
    }
}
