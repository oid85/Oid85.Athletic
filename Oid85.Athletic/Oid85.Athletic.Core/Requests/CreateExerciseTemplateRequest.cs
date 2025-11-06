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
        public required string Name { get; set; }

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
