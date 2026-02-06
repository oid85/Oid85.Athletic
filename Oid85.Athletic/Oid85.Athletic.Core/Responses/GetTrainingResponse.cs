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
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; } = string.Empty;

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
        public List<ExerciseItemResponse>? Exercises { get; set; }
    }

    /// <summary>
    /// Упражнение
    /// </summary>
    public class ExerciseItemResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

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
