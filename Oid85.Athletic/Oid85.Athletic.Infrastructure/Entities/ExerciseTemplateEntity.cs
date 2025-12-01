using System.ComponentModel.DataAnnotations;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    /// <summary>
    /// Шаблон упражнения
    /// </summary>
    public class ExerciseTemplateEntity : BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(500)]
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
