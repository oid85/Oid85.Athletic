namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на редактирование тренировки
    /// </summary>
    public class EditTrainingRequest
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
        /// Описание
        /// </summary>
        public string? Description { get; set; } = string.Empty;
    }
}
