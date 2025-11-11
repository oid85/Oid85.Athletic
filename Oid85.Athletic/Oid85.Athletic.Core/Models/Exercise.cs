using Oid85.Athletic.Core.Models.Base;

namespace Oid85.Athletic.Core.Models
{
    /// <summary>
    /// Упражнение
    /// </summary>
    public class Exercise : BaseModel
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
        public double? Weight { get; set; }

        /// <summary>
        /// Шаблон упражнения
        /// </summary>
        public ExerciseTemplate ExerciseTemplate { get; set; } = new();
    }
}
