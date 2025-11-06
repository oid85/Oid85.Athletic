namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на редактирование шаблона упражнения
    /// </summary>
    public class EditExerciseTemplateRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public required Guid Id { get; set; }

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
