using Oid85.Athletic.Core.Models.Base;

namespace Oid85.Athletic.Core.Models
{
    public class ExerciseTemplate : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public string Equipment { get; set; } = string.Empty;
    }
}
