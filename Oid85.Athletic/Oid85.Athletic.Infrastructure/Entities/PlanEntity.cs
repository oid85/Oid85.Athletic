using System.ComponentModel.DataAnnotations.Schema;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    public class PlanEntity : BaseEntity
    {
        public DateOnly Date { get; set; }

        public TrainingEntity MorningTraining { get; set; }

        public TrainingEntity DayTraining { get; set; }
    }
}
