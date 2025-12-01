namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на создание шаблона упражнения
    /// </summary>
    public class CreateExerciseTemplateRequest
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
