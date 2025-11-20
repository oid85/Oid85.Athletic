namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Удалить утреннюю тренировку
    /// </summary>
    public class RemovePlanMorningTrainingRequest
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateOnly Date { get; set; }
    }
}
