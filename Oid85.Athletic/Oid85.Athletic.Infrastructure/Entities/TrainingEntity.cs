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
        public required string Name { get; set; }

        /// <summary>
        /// Циклы
        /// </summary>
        [MaxLength(500)]
        public string? Cycles { get; set; }

        /// <summary>
        /// Список упражнений
        /// </summary>
        public ICollection<ExerciseEntity>? Exercises { get; set; }
    }
}
