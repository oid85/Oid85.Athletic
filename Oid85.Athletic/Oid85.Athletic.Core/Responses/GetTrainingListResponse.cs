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
        public List<TrainingListItem> Trainings { get; set; } = [];
    }

    /// <summary>
    /// Тренировка
    /// </summary>
    public class TrainingListItem
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
