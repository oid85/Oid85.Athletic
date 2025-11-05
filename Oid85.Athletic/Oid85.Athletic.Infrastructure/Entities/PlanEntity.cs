using System.ComponentModel.DataAnnotations.Schema;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    public class PlanEntity : BaseEntity
    {
        [Column("date", TypeName = "date")]
        public DateOnly Date { get; set; }

        [Column("morning_training_id")]
        public Guid MorningTrainingId { get; set; }

        [Column("day_training_id")]
        public Guid DayTrainingId { get; set; }

        public TrainingEntity MorningTraining { get; set; } = new();

        public TrainingEntity DayTraining { get; set; } = new();
    }
}
