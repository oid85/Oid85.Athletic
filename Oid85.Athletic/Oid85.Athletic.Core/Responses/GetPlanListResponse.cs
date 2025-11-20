namespace Oid85.Athletic.Core.Responses
{
    /// <summary>
    /// Запланированные тренировки
    /// </summary>
    public class GetPlanListResponse
    {
        /// <summary>
        /// Список шаблонов упражнений
        /// </summary>
        public List<PlanListItemResponse> PlanTrainings { get; set; } = [];
    }

    /// <summary>
    /// План
    /// </summary>
    public class PlanListItemResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Утренняя тренировка
        /// </summary>
        public TrainingItemResponse? MorningTraining { get; set; }

        /// <summary>
        /// Дневная тренировка
        /// </summary>
        public TrainingItemResponse? DayTraining { get; set; }
    }

    /// <summary>
    /// Тренировка
    /// </summary>
    public class TrainingItemResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string? Name { get; set; }
    }
}
