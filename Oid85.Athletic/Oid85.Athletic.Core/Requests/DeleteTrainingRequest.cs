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
        public Guid Id { get; set; }
    }
}
