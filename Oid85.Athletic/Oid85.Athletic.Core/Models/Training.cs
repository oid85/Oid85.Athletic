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
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Циклы
        /// </summary>
        public int? Cycles { get; set; }

        /// <summary>
        /// Список упражнений
        /// </summary>
        public List<Exercise>? Exercises { get; set; }
    }
}
