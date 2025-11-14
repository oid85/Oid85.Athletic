namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на редактирование длительности заминки
    /// </summary>
    public class EditTrainingFinishCardioMinutesRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Длительность заминочного кардио
        /// </summary>
        public int FinishCardioMinutes { get; set; }
    }
}
