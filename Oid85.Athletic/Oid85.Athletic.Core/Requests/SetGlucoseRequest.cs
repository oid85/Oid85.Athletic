namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// Редактирование измерения глюкозы
    /// </summary>
    public class SetGlucoseRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Тип измерения
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public double? Value { get; set; }
    }
}
