namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Запрос на создание упражнения
    /// </summary>
    public class CreateExerciseRequest
    {
        /// <summary>
        /// Идентификатор шаблона упражнения
        /// </summary>
        public Guid ExerciseTemplateId { get; set; }

        /// <summary>
        /// Идентификатор тренировки
        /// </summary>
        public Guid TrainingId { get; set; }
    }
}
