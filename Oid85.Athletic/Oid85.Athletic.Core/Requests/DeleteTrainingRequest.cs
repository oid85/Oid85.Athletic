namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на удаление тренировки
    /// </summary>
    public class DeleteTrainingRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public required Guid Id { get; set; }
    }
}
