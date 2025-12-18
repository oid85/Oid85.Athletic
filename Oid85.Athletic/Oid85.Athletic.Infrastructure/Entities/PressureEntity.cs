using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oid85.Athletic.Infrastructure.Entities.Base;

namespace Oid85.Athletic.Infrastructure.Entities
{
    /// <summary>
    /// Артериальное давление
    /// </summary>
    public class PressureEntity : BaseEntity
    {
        /// <summary>
        /// Дата и время измерения
        /// </summary>
        [Required]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Систолическое
        /// </summary>
        public int Sys { get; set; }

        /// <summary>
        /// Диастолическое
        /// </summary>
        public int Dia { get; set; }

        /// <summary>
        /// Пульс
        /// </summary>
        public int? Pulse { get; set; }
    }
}
