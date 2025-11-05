using Oid85.Athletic.Core.Models.Base;

namespace Oid85.Athletic.Core.Models
{
    public class Plan : BaseModel
    {
        public DateOnly Date { get; set; }

        public Training MorningTraining { get; set; }

        public Training DayTraining { get; set; }
    }
}
