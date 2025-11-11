namespace Oid85.Athletic.Core.Responses
{
    /// <summary>
    /// Ответ на запрос получения списка шаблонов упражнений
    /// </summary>
    public class GetExerciseTemplateListResponse
    {
        /// <summary>
        /// Список шаблонов упражнений
        /// </summary>
        public List<ExerciseTemplateListItemResponse> ExerciseTemplates { get; set; } = [];
    }

    /// <summary>
    /// Шаблон упражнения
    /// </summary>
    public class ExerciseTemplateListItemResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Задействованные мышцы
        /// </summary>
        public string Muscles { get; set; } = string.Empty;

        /// <summary>
        /// Оборудование
        /// </summary>
        public string Equipment { get; set; } = string.Empty;
    }
}
