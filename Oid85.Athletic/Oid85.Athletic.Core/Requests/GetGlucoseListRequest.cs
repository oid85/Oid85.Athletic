namespace Oid85.Athletic.Core.Requests
{
    /// <summary>
    /// История измерений глюкозы
    /// </summary>
    public class GetGlucoseListRequest
    {
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateOnly From { get; set; }

        /// <summary>
        /// Дата конца
        /// </summary>
        public DateOnly To { get; set; }
    }
}
