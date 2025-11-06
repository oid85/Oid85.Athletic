namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на удаление шаблона упражнения
    /// </summary>
    public class DeleteExerciseTemplateRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public required Guid Id { get; set; }
    }
}
