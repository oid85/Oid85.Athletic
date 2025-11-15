using System.ComponentModel.DataAnnotations;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    /// <summary>
    /// План
    /// </summary>
    public class PlanEntity : BaseEntity
    {
        /// <summary>
        /// Дата
        /// </summary>
        [Required]
        public DateOnly Date { get; set; }

        /// <summary>
        /// Зарядка
        /// </summary>
        public TrainingEntity? MorningTraining { get; set; }

        /// <summary>
        /// Дневная тренировка
        /// </summary>
        public TrainingEntity? DayTraining { get; set; }
    }
}
