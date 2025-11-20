namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Удалить утредневную тренировку
    /// </summary>
    public class RemovePlanDayTrainingRequest
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateOnly Date { get; set; }
    }
}
