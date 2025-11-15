namespace Oid85.Athletic.Core.Responses
{
    /// <summary>
    /// Ответ на запрос получения списка тренировок
    /// </summary>
    public class GetTrainingListResponse
    {
        /// <summary>
        /// Список шаблонов упражнений
        /// </summary>
        public List<TrainingListItemResponse> Trainings { get; set; } = [];
    }

    /// <summary>
    /// Тренировка
    /// </summary>
    public class TrainingListItemResponse
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
        /// Общее количество повторений
        /// </summary>
        public int? TotalCountIterations { get; set; }

        /// <summary>
        /// Общий вес
        /// </summary>
        public double? TotalWeight { get; set; }
    }
}
