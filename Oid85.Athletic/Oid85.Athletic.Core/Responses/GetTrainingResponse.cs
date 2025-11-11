using Oid85.Athletic.Core.Models;

namespace Oid85.Athletic.Core.Responses
{
    /// <summary>
    /// Ответ на запрос получения тренировки по идентификатору
    /// </summary>
    public class GetTrainingResponse
    {
        /// <summary>
        /// Тренировка
        /// </summary>
        public GetTrainingItemResponse Training { get; set; } = new();
    }

    /// <summary>
    /// Тренировка
    /// </summary>
    public class GetTrainingItemResponse
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Циклы
        /// </summary>
        public string? Cycles { get; set; }

        /// <summary>
        /// Список упражнений
        /// </summary>
        public List<ExerciseItemResponse>? Exercises { get; set; }
    }

    /// <summary>
    /// Упражнение
    /// </summary>
    public class ExerciseItemResponse
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;

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
    }
}
