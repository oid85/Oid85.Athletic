using Oid85.Athletic.Core.Models.Base;

namespace Oid85.Athletic.Core.Models
{
    /// <summary>
    /// План
    /// </summary>
    public class Plan : BaseModel
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Дневная тренировка
        /// </summary>
        public Training? DayTraining { get; set; }
    }
}
