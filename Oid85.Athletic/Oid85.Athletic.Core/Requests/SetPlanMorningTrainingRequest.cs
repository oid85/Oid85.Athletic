namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запланировать утреннюю тренировку
    /// </summary>
    public class SetPlanMorningTrainingRequest
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Идентификатор тренировки
        /// </summary>
        public Guid TrainingId { get; set; }
    }
}
