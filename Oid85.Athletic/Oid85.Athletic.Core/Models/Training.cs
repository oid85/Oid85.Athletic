using Oid85.Athletic.Core.Models.Base;

namespace Oid85.Athletic.Core.Models
{
    /// <summary>
    /// Тренировка
    /// </summary>
    public class Training : BaseModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Циклы
        /// </summary>
        public string? Cycles { get; set; }

        /// <summary>
        /// Список упражнений
        /// </summary>
        public List<Exercise>? Exercises { get; set; }
    }
}
