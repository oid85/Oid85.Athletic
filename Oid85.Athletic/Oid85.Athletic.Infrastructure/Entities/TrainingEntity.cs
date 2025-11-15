using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    /// <summary>
    /// Тренировка
    /// </summary>
    public class TrainingEntity : BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(500)]
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Циклы
        /// </summary>
        public int? Cycles { get; set; }

        /// <summary>
        /// Длительность разминочного кардио
        /// </summary>
        public int? StartCardioMinutes { get; set; }

        /// <summary>
        /// Длительность заминочного кардио
        /// </summary>
        public int? FinishCardioMinutes { get; set; }

        /// <summary>
        /// Общее количество повторений
        /// </summary>
        public int? TotalCountIterations { get; set; }

        /// <summary>
        /// Общий вес
        /// </summary>
        [Column(TypeName = "decimal(6,1)")]
        public double? TotalWeight { get; set; }

        /// <summary>
        /// Список упражнений
        /// </summary>
        public ICollection<ExerciseEntity>? Exercises { get; set; }
    }
}
