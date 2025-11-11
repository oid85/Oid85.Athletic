using Oid85.Athletic.Core.Models.Base;

namespace Oid85.Athletic.Core.Models
{
    /// <summary>
    /// Шаблон упражнения
    /// </summary>
    public class ExerciseTemplate : BaseModel
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Задействованные мышцы
        /// </summary>
        public string? Muscles { get; set; }

        /// <summary>
        /// Оборудование
        /// </summary>
        public string? Equipment { get; set; }
    }
}
