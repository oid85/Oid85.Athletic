namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на редактирование упражнения
    /// </summary>
    public class EditExerciseRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Количество повторений
        /// </summary>
        public int? CountIterations { get; set; }

        /// <summary>
        /// Время в минутах
        /// </summary>
        public int? Minutes { get; set; }

        /// <summary>
        /// Порядковый номер упражнения в тренировке
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        /// Вес снаряда
        /// </summary>
        public double? Weight { get; set; }
    }
}
