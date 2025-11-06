namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на получение списка шаблонов упражнений
    /// </summary>
    public class GetExerciseTemplateListRequest
    {
        /// <summary>
        /// Оборудование
        /// </summary>
        public string? Equipment { get; set; } = null;
    }
}
