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

        /// <summary>
        /// Задействованные мышцы
        /// </summary>
        public string? Muscles { get; set; }

        /// <summary>
        /// Оборудование
        /// </summary>
        public string? Equipment { get; set; }
    }
}
