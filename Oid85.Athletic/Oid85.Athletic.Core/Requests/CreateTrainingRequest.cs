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
        public required string Name { get; set; }
    }
}
