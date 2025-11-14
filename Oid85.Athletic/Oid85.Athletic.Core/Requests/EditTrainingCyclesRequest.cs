namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на редактирование количества циклов в тренировке
    /// </summary>
    public class EditTrainingCyclesRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Количество циклов
        /// </summary>
        public int Cycles { get; set; }
    }
}
