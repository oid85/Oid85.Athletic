namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на удаление упражнения
    /// </summary>
    public class DeleteExerciseRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
