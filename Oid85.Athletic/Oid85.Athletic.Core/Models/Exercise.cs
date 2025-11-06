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
        public required ExerciseTemplate ExerciseTemplate { get; set; }

        /// <summary>
        /// Тренировка
        /// </summary>
        public required Training Training { get; set; }
    }
}
