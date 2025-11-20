namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запланированные тренировки
    /// </summary>
    public class GetPlanListRequest
    {
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateOnly From { get; set; }

        /// <summary>
        /// Дата конца
        /// </summary>
        public DateOnly To { get; set; }
    }
}
