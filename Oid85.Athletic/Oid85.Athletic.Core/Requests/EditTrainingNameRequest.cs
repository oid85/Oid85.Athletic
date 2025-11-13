namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на редактирование наименования тренировки
    /// </summary>
    public class EditTrainingNameRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
