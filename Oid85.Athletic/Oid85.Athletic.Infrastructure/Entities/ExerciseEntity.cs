using System.ComponentModel.DataAnnotations.Schema;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    public class ExerciseEntity : BaseEntity
    {
        [Column("count_iterations")]
        public int CountIterations { get; set; }

        [Column("order")]
        public int Order { get; set; }

        [Column("exercise_template_id")]
        public Guid ExerciseTemplateId { get; set; }

        [Column("training_id")]
        public Guid TrainingId { get; set; }

        public ExerciseTemplateEntity ExerciseTemplate { get; set; } = new();

        public TrainingEntity Training { get; set; } = new();
    }
}
