namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на редактирование длительности разминки
    /// </summary>
    public class EditTrainingStartCardioMinutesRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Длительность разминочного кардио
        /// </summary>
        public int StartCardioMinutes { get; set; }
    }
}
