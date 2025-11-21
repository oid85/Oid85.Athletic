namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Удалить утреннюю тренировку
    /// </summary>
    public class RemovePlanTrainingRequest
    {
        /// <summary>
        /// Идентификатор плана
        /// </summary>
        public Guid PlanId { get; set; }

        /// <summary>
        /// Идентификатор тренировки
        /// </summary>
        public Guid TrainingId { get; set; }
    }
}
