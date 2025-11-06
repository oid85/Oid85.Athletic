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
        public required Guid Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Циклы
        /// </summary>
        public string? Cycles { get; set; }
    }
}
