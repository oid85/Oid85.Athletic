namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на получение тренировки по идентификатору
    /// </summary>
    public class GetTrainingRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public required Guid Id { get; set; }
    }
}
