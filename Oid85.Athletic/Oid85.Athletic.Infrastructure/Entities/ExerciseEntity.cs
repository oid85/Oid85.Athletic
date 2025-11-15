using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    /// <summary>
    /// Упражнение
    /// </summary>
    public class ExerciseEntity : BaseEntity
    {
        /// <summary>
        /// Количество повторений
        /// </summary>
        public int? CountIterations { get; set; }

        /// <summary>
        /// Время в минутах
        /// </summary>
        public int? Minutes { get; set; }

        /// <summary>
        /// Порядковый номер упражнения в тренировке
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        /// Вес снаряда
        /// </summary>
        [Column(TypeName = "decimal(4,1)")]
        public double? Weight { get; set; }

        /// <summary>
        /// Шаблон упражнения
        /// </summary>
        [Required]
        public ExerciseTemplateEntity ExerciseTemplate { get; set; } = new();

        /// <summary>
        /// Тренировка
        /// </summary>
        [Required]
        public TrainingEntity Training { get; set; } = new();
    }
}
