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
        public double? TotalWeight { get; set; }

        /// <summary>
        /// Список упражнений
        /// </summary>
        public List<Exercise>? Exercises { get; set; }
    }
}
