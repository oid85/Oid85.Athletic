namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на создание тренировки
    /// </summary>
    public class CreateTrainingRequest
    {
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
